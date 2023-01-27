(function ($) {
    function productGallary() {
        var $this = this;

        function initilizeModel() {
            $("#modal-product-gallary-show").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new productGallary();
        self.init();
    })
}(jQuery))
