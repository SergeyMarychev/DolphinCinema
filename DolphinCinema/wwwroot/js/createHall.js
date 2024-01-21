import toast from "/js/components/toast.js"; 

document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("createHallSave").addEventListener("click", function () {
        const hall = {
            seats: []
        }

        let currentRow = 1;
        let offsetTop = 0;
        document.querySelectorAll(".hall__template .row").forEach(row => {
            let currentSeat = 1;
            let offsetLeft = 0;
            row.querySelectorAll(".seat").forEach(seat => {
                if (seat.classList.contains("active")) {
                    hall.seats.push({
                        row: currentRow,
                        number: currentSeat++,
                        offsetTop: offsetTop,
                        offsetLeft: offsetLeft,
                    })
                    offsetLeft = 0;
                } else {
                    offsetLeft++;
                }
            })

            if (currentSeat == 1) {
                offsetTop++;
            } else {
                offsetTop = 0;
                currentRow++;
            }
        });

        hall.name = document.getElementById("name__input").value;

        axios.post('/admin/hall/create', hall)
            .then(function (response) {
                console.log(response);
                location.reload();
            })
            .catch(function (error) {
                if (error.response.status === 400) {
                    const errorContainer = document.querySelector('.name__input-errorMessage');
                    errorContainer.innerHTML = error.response.data;
                    errorContainer.style.display = 'block';                    
                } else {
                    toast("error", "Внимание!", "Что-то пошло не так.");
                }
            });
    })

    document.getElementById("createHall").addEventListener("click", function () {
        const inputRow = document.getElementById("size__input_row").value;
        const inputSeat = document.getElementById("size__input_seat").value;
        const numberOfRows = 30;
        const numberOfSeats = 15;

        let errorMessage = "";

        if (!inputRow || inputRow <= 0 ) {
            errorMessage += "Введите количество рядов больше 0.<br>";
        }

        if (!inputSeat || inputSeat <= 0) {
            errorMessage += "Введите количество мест больше 0.<br>";
        }

        if (inputRow > numberOfRows) {
            errorMessage += `Количество рядов не может быть больше ${numberOfRows}.<br>`;
        }

        if (inputSeat > numberOfSeats) {
            errorMessage += `Количество мест в ряду не может быть больше ${numberOfSeats}.<br>`;
        }

        const errorContainer = document.querySelector('.size__input-errorMessage');
        errorContainer.innerHTML = errorMessage;

        if (errorMessage) {
            errorContainer.style.display = 'block'; 
            return;
        } 

        errorContainer.style.display = 'none'; 
        
        const hallPreview = document.querySelector(".hall__preview");
        const hallGrid = hallPreview.querySelector(".hall__grid");

        if (hallGrid) {
            hallGrid.remove(); 
        }

        let hallHTML = `
            <div class="hall__grid">
                <div class="display">Экран</div>
                <div class="hall__template">`;

        for (let i = 0; i < inputRow; i++) {
            hallHTML += `<div class="row">`;
            for (let j = 0; j < inputSeat; j++) {
                hallHTML += `<div class="seat active"></div>`;
            }
            hallHTML += `</div>`;
        }

        hallHTML += `
                </div>
            </div>`;

        hallPreview.insertAdjacentHTML('beforeend', hallHTML);
        document.querySelector(".hallPreview__wrapper").classList.remove("d-none");
        document.querySelectorAll(".seat").forEach(seat => {
            seat.addEventListener("click", function () {
                if (this.classList.contains("active")) {
                    this.classList.remove("active")
                } else {
                    this.classList.add("active")
                }
            })
        })
    })
})