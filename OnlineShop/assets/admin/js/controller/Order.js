var Order = {
    init: function () {
        Order.registerEvents();
    },
    registerEvents: function () {
        $('.btn-images').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                url: '/Admin/Order/LoadOrder',
                type: 'GET',
                data: {
                    id: $(this).attr('data-id')
                },
                dataType: 'json',
                success: function (response) {
                    var data = response.data;
                    var html = '<table><tr class="thead"> <th class="th_1">Ảnh sản phẩm</th> <th>Tên sản phẩm</th> <th class="th_1">Số lượng</th> <th class="th_1">Đơn giá</th> <th class="th_1">Thành tiền</th> </tr>';
                    $.each(data, function (i, item) {
                        html += item;
                    });
                    html += '</table>';
                    $('.giohang').html(html);

               

                    //thong bao thanh cong
                }
            });




            $('#myModal').modal('show');








        })
    }
}
Order.init();