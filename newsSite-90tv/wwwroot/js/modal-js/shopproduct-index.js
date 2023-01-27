(function ($) {
    function shopproduct() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-shopproducts").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new shopproduct();
        self.init();
    })
}(jQuery))
