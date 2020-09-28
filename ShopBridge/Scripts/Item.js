function checkDec(el) {
    var ex = /^[0-9]+\.?[0-9]*$/;
    if (ex.test(el.value) == false) {
        el.value = el.value.substring(0, el.value.length - 1);
    }
}
$(document).ready(function () {
    var vm = {
    };

    var validator = $("#newitem").validate({
        submitHandler: function () {
            ; debugger
            vm.name = $("#name").val();
            vm.desc = $("#desc").val();
            vm.price = $("#price").val();
            $('#btnsave').prop('disabled', true);
            $.ajax({
                url: "/api/Item",
                method: "post",
                data: vm
            })
                .done(function () {
                    toastr.success("Item added successfully.");
                    $("#name").val("");
                    $("#desc").val("");
                    $("#price").val("");
                    $('#btnsave').prop('disabled', false);
                    vm = {};
                    validator.resetForm();
                    refresh_tab();
                })
                .fail(function () {
                    toastr.error("Something unexpected happened.");
                    vm = {};
                    $('#btnsave').prop('disabled', false);
                });

            return false;
        }
    });
});
var table
$(document).ready(function () {
    table = $("#customers").DataTable({
        ajax: {
            url: "/api/Item",
            dataSrc: ""
        },
        order: []
        ,
        columns: [
            {
                data: "name",
                render: function (data, type, item) {
                    return "<a href='/item/ItemDetail/" + item.id + "'>" + item.name + "</a>";
                }
            },
            {
                data: "price"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-item-id=" + data + ">Delete</button>";
                }
            }
        ]
    });


    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Items?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/item/" + button.attr("data-item-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                        toastr.success("Item remove successfully.");
                    }
                });
            }
        });
    });

});
function refresh_tab() {
    table.ajax.reload();
}