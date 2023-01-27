(function ($) {
    function filemanager() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-gallary").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new filemanager();
        self.init();
    })
}(jQuery))
