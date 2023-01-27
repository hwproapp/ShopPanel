(function ($) {
    function subCategory() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-detail-category").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new subCategory();
        self.init();
    })
}(jQuery))
