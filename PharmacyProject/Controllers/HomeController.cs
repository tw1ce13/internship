using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Controllers;

public class HomeController : Controller
{
    private readonly PharmacyContext _context;
    private readonly IWebService _webService;
    private readonly IOrderService _orderService;
    private readonly IPharmacyService _pharmacyService;
    private readonly IDrugService _drugService;
    private readonly IAvailabilityService _availabilityService;
    private readonly IDeliveryService _deliveryService;
    private readonly IClassService _classService;
    private readonly IPatientService _patientService;
    private readonly IDiscountService _discountService;
    private readonly IOrdDrugService _ordDrugService;
    public static bool isRegistered = true;

    public HomeController(IOrdDrugService ordDrugService, IDiscountService discountService,IPatientService patientService, PharmacyContext context, IClassService classService, IOrderService orderService, IPharmacyService pharmacyService, IWebService webService, IDrugService drugService, IAvailabilityService availabilityService, IDeliveryService deliveryService)
    {
        _context = context;
        _classService = classService;
        _orderService = orderService;
        _pharmacyService = pharmacyService;
        _webService = webService;
        _drugService = drugService;
        _availabilityService = availabilityService;
        _deliveryService = deliveryService;
        _patientService = patientService;
        _discountService = discountService;
        _ordDrugService = ordDrugService;
    }

    public async Task<ActionResult> Index()
    {
        ViewBag.Flag = isRegistered;
        var baseResponse = await _webService.GetAll();
        var list = baseResponse.Data;
        return View(list);
    }

    [HttpGet]
    public async Task<ActionResult> GetPharmacyAddresses(int webId)
    {
        var baseResponse = await _pharmacyService.GetAll();
        var pharmacies = baseResponse.Data.Where(p => p.IdWeb == webId);
        ViewBag.Pharmacy = pharmacies;
        return PartialView("_PharmacyAddressesPartialView", ViewBag.Pharmacy);
    }

    public async Task<ActionResult> GetDrugs(int pharmacyId, CancellationToken cancellationToken)
    {
        HttpContext.Session.SetInt32("PharmacyId", pharmacyId);
        ViewBag.Flag = isRegistered;
        var baseResponseDrug = await _drugService.GetAll(cancellationToken);
        var baseResponseAvailability = await _availabilityService.GetAvailabilitiesByPharmacyId(pharmacyId);
        var baseResponseDelivery = await _deliveryService.GetFresh();
        var baseResponseAvailabilityFresh = await _availabilityService.GetAvailabilityByDelivery(baseResponseDelivery.Data);
        var baseResponseClass = await _classService.GetAll();
        var availabilities = from availability in baseResponseAvailability.Data
                             join avail in baseResponseAvailabilityFresh.Data on new { availability.PharmacyId, availability.DeliveryId }
                             equals new { avail.PharmacyId, avail.DeliveryId }
                             select availability;
        var drugs = await _drugService.GetDrugs(availabilities, baseResponseClass.Data, baseResponseDelivery.Data);

        return View(drugs.Data);
    }

    public ActionResult Register()
    {
        var flag = TempData["Flag"];
        if (flag != null)
            ViewBag.Flag = TempData["Flag"];
        else
            ViewBag.Flag = true;
        return View();
    }

    public async Task<ActionResult> ShowDiscounts()
    {
        ViewBag.Flag = isRegistered;
        var discounts = await _discountService.GetAll();
        return View(discounts.Data);
    }

    [HttpPost]
    public ActionResult AddUser(string email, string password, string firstName, string lastName, string age, string mainDiagnosis, string subDiagnosis, bool privelege)
    {
        int userAge;
        if (int.TryParse(age, out userAge))
        {
            Patient patient = new Patient()
            {
                Email = email,
                Password = password,
                Name = firstName,
                Surname = lastName,
                Age = userAge,
                MainDiagnosis = mainDiagnosis,
                SubDiagnosis = subDiagnosis,
                IsPrivilege = privelege

            };
            _patientService.Add(patient);
            isRegistered = false;
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> AddToOrder(int itemId, int quantity)
    {
        var patients = await _patientService.GetAll();
        var dataPatient = patients.Data.Last();
        var userId = dataPatient.Id;
        HttpContext.Session.SetInt32("UserId", userId);
        Random random = new Random();
        int? pharmacyId = HttpContext.Session.GetInt32("PharmacyId");
        int employeeId = random.Next(7, 186);
        if (pharmacyId.HasValue && !isRegistered)
        {
            Order order = new Order()
            {
                Date = DateTime.Now.ToUniversalTime(),
                DiscountId = 5,
                PharmacyId = (int)pharmacyId,
                PatientId = userId,
                EmployeeId = employeeId
            };
            _orderService.Add(order);

            var drug = await _drugService.Get(itemId);
            var orders = await _orderService.GetAll();
            var dataOrder = orders.Data.Last();
            var orderId = dataOrder.Id;
            OrdDrug ordDrug = new OrdDrug()
            {
                OrderId = orderId,
                DrugId = itemId,
                DiscountId = 5,
                Count = quantity,
                Price = quantity * drug.Data.Cost
            };
            _ordDrugService.Add(ordDrug);
            return RedirectToAction("Catalog", "Home", new { selectedOption2 = pharmacyId });
        }
        return RedirectToAction("Register", "Home");
    }

    public async Task<ActionResult> ShowItemsInOrder(CancellationToken cancellationToken)
    {
        ViewBag.Flag = isRegistered;
        int? userId = HttpContext.Session.GetInt32("UserId");
        var baseResponseDrug = await _drugService.GetAll(cancellationToken);
        var baseRespnseOrd = await _orderService.GetAll();
        var baseResponseOrdDrug = await _ordDrugService.GetAll();
        var list = (from drug in baseResponseDrug.Data
                    join ordDrug in baseResponseOrdDrug.Data on drug.Id equals ordDrug.DrugId
                    join order in baseRespnseOrd.Data on userId equals order.PatientId
                    select new
                    {
                        drug.Name,
                        ordDrug.Count,
                        ordDrug.Price,
                        order.Date
                    })
            .GroupBy(x => x.Name)
            .Select(g => g.FirstOrDefault())  
            .ToList();

        return View(list);
    }
}

