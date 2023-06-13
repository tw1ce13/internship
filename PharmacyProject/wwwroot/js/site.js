<script>$(document).ready(function () {
    $("#selectBox").change(function () {
        var selectedWebId = $(this).val();
        $.ajax({
            type: "GET",
            url: "/Home/GetPharmacyAddresses",
            data: { webId: selectedWebId },
            success: function (result) {
                $("#selectBox2").html(result);
            },
            error: function (result) {
                alert("Ошибка при загрузке данных");
            }
        });
    });
        });</script>