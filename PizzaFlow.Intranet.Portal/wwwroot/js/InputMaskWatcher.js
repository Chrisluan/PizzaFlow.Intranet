document.addEventListener("DOMContentLoaded", function () {

    document.querySelectorAll("[data-mask]").forEach(input => {

        const mask = input.getAttribute("data-mask");

        input.addEventListener("input", function (e) {
            
            
                
            let value = e.target.value.replace(/\D/g, "");
            let masked = "";
            let vi = 0;

            for (let i = 0; i < mask.length && vi < value.length; i++) {
                if (mask[i] === "0") {
                    masked += value[vi++];
                } else {
                    masked += mask[i];
                }
            }

            e.target.value = masked;
        });

    });

});
