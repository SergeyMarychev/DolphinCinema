document.querySelectorAll('.timeBtn').forEach(btn => btn.addEventListener("click", function () {
    const date = this.dataset.date;

    const dateString = moment(date).format("L");

    axios.get("Home/GetPosterItems", {
        params: {
            date: dateString
        },
        responseType: "text/html"
    }).then(function (response) {
        document.getElementById("posterItems").innerHTML = response.data;
    })
}));