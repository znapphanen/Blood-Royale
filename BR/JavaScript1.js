(function () {
    "use strict";
    debugger;
    var lerror = document.getElementById("lblError");
        lerror.addEventListener('change', test(lerror));

    function test(labelErr)
    {
        if (labelErr.innerHTML != '')
        {
            window.alert(labelErr.innerHTML);
            labelErr.innerHTML = "";
        };
    }

})();

