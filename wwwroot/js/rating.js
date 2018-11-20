(function ($) {
    function Rating() {
        var $this = this;
        function initialize() {
            $("#1, #2, #3, #4, #5").click(function () {
                $(".star").removeClass('active');
                $(this).addClass('active');
                var starValue = $(this).data("value");
                $("#Review_Stars").val(starValue);
            })
        }
        $this.init = function () {
            initialize();
        }
    }
    $(function () {
        var self = new Rating();
        self.init();
    })
}(jQuery))