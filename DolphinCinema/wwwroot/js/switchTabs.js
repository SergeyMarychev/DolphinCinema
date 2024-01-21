document.addEventListener("DOMContentLoaded", function () {
    var tabs = document.querySelectorAll(".tabs__item");

    tabs.forEach(function (tab) {
        tab.addEventListener("click", function () {
            document.querySelector(".tabs__item.active").classList.remove("active");
            document.querySelector(".tabs__block.active").classList.remove("active");

            tab.classList.add("active");

            let target = this.dataset.target;
            document.querySelector(target).classList.add("active");
        });
    });
});
