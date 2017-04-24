   function getSeoTitle(input) {
            if (input == undefined || input == '')
                return '';
            //Đổi chữ hoa thành chữ thường
            var slug = input.toLowerCase();

            // ký tự đặc biệt
            slug = slug.replace(/ắ/gi, 'a');
            slug = slug.replace(/ẳ/gi, 'a');
            slug = slug.replace(/ẵ/gi, 'a');
            slug = slug.replace(/ặ/gi, 'a');
            slug = slug.replace(/ằ/gi, 'a');
            slug = slug.replace(/ă/gi, 'a');

            slug = slug.replace(/á/gi, 'a');
            slug = slug.replace(/ả/gi, 'a');
            slug = slug.replace(/ã/gi, 'a');
            slug = slug.replace(/ạ/gi, 'a');
            slug = slug.replace(/à/gi, 'a');

            slug = slug.replace(/ấ/gi, 'a');
            slug = slug.replace(/ẩ/gi, 'a');
            slug = slug.replace(/ẫ/gi, 'a');
            slug = slug.replace(/ậ/gi, 'a');
            slug = slug.replace(/ầ/gi, 'a');
            slug = slug.replace(/â/gi, 'a');

            slug = slug.replace(/ớ/gi, 'o');
            slug = slug.replace(/ở/gi, 'o');
            slug = slug.replace(/ỡ/gi, 'o');
            slug = slug.replace(/ợ/gi, 'o');
            slug = slug.replace(/ờ/gi, 'o');
            slug = slug.replace(/ơ/gi, 'o');

            slug = slug.replace(/ố/gi, 'o');
            slug = slug.replace(/ổ/gi, 'o');
            slug = slug.replace(/ỗ/gi, 'o');
            slug = slug.replace(/ộ/gi, 'o');
            slug = slug.replace(/ồ/gi, 'o');
            slug = slug.replace(/ô/gi, 'o');

            slug = slug.replace(/ó/gi, 'o');
            slug = slug.replace(/ỏ/gi, 'o');
            slug = slug.replace(/õ/gi, 'o');
            slug = slug.replace(/ọ/gi, 'o');
            slug = slug.replace(/ò/gi, 'o');

            slug = slug.replace(/ế/gi, 'e');
            slug = slug.replace(/ể/gi, 'e');
            slug = slug.replace(/ễ/gi, 'e');
            slug = slug.replace(/ệ/gi, 'e');
            slug = slug.replace(/ề/gi, 'e');
            slug = slug.replace(/ê/gi, 'e');

            slug = slug.replace(/é/gi, 'e');
            slug = slug.replace(/ẻ/gi, 'e');
            slug = slug.replace(/ẽ/gi, 'e');
            slug = slug.replace(/ẹ/gi, 'e');
            slug = slug.replace(/è/gi, 'e');

            slug = slug.replace(/ứ/gi, 'u');
            slug = slug.replace(/ử/gi, 'u');
            slug = slug.replace(/ữ/gi, 'u');
            slug = slug.replace(/ự/gi, 'u');
            slug = slug.replace(/ừ/gi, 'u');
            slug = slug.replace(/ư/gi, 'u');

            slug = slug.replace(/ú/gi, 'u');
            slug = slug.replace(/ủ/gi, 'u');
            slug = slug.replace(/ũ/gi, 'u');
            slug = slug.replace(/ụ/gi, 'u');
            slug = slug.replace(/ù/gi, 'u');

            slug = slug.replace(/í/gi, 'i');
            slug = slug.replace(/ỉ/gi, 'i');
            slug = slug.replace(/ĩ/gi, 'i');
            slug = slug.replace(/ị/gi, 'i');
            slug = slug.replace(/ì/gi, 'i');

            slug = slug.replace(/ý/gi, 'y');
            slug = slug.replace(/ỷ/gi, 'y');
            slug = slug.replace(/ỹ/gi, 'y');
            slug = slug.replace(/ỵ/gi, 'y');
            slug = slug.replace(/ỳ/gi, 'y');

            slug = slug.replace(/đ/gi, 'd');
            //Xóa các ký tự đặt biệt
            slug = slug.replace(/\`|\~|\!|\@|\#|\||\$|\%|\^|\&|\*|\(|\)|\+|\=|\,|\.|\/|\?|\>|\<|\'|\"|\:|\;|_/gi, '');
            //Đổi khoảng trắng thành ký tự gạch ngang
            slug = slug.replace(/ /gi, "-");
            //Đổi nhiều ký tự gạch ngang liên tiếp thành 1 ký tự gạch ngang
            //Phòng trường hợp người nhập vào quá nhiều ký tự trắng
            slug = slug.replace(/\-\-\-\-\-/gi, '-');
            slug = slug.replace(/\-\-\-\-/gi, '-');
            slug = slug.replace(/\-\-\-/gi, '-');
            slug = slug.replace(/\-\-/gi, '-');
            //Xóa các ký tự gạch ngang ở đầu và cuối
            slug = '@' + slug + '@';
            slug = slug.replace(/\@\-|\-\@|\@/gi, '');

            return slug;
        }