(function ($) {
    function userApp() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-detail-userApp").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new userApp();
        self.init();
    })
}(jQuery))