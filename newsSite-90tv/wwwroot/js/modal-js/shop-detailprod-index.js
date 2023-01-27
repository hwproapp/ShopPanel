(function ($) {
    function shopdetail() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-shop-detailprod").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new shopdetail();
        self.init();
    })
}(jQuery))
