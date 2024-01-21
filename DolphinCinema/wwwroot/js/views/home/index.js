document.addEventListener('DOMContentLoaded', function () {
    const popupContainer = document.querySelector("#posterModal");

    document.querySelectorAll('.poster__btn').forEach(posterBtn => {
        posterBtn.addEventListener('click', function (event) {
            const target = event.target.closest('.poster__btn');
            if (target) {
                const seanceId = target.dataset.seanceId;

                axios.get(
                    "/seance/SeanceModal", {
                    params: {
                        seanceId: seanceId
                    }
                }).then(function (response) {
                    const html = response.data;
                    popupContainer.querySelector(".modal__content").innerHTML = html;

                    popupContainer.querySelectorAll(".seat").forEach(seat => {
                        tippy(seat, {
                            arrow: true,
                            content: seat.dataset.title,
                            theme: "seat"
                        });

                        seat.addEventListener("click", function () {
                            showTicketCard(this.dataset);
                            toggleSeatState(this);
                        });
                    });

                    const popupExit = popupContainer.querySelector('.modal__exit');
                    const closePopup = () => {
                        popupContainer.setAttribute('hidden', '');
                    };

                    popupExit.addEventListener('click', closePopup);
                    popupContainer.removeAttribute('hidden');
                });
            }
        });
    });

    const toggleSeatState = (seat) => {
        if (seat.classList.contains("active")) {
            seat.classList.remove("active");
            document.querySelectorAll(".seat.disabled").forEach(s => s.classList.remove("disabled"));
        } else {
            const activeCount = document.querySelectorAll(".seat.active").length;
            if (activeCount == 4) {
                seat.classList.add("active");
                document.querySelectorAll(".seat:not(.active)").forEach(s => s.classList.add("disabled"));
                return;
            }
            seat.classList.add("active");
        }
    };

    const showTicketCard = (data) => {
        let ticketCardsContainer = document.querySelector('.ticket-cards');

        // Ищем карточку с данными о месте
        const existingCard = ticketCardsContainer.querySelector(`.ticket-cards__item[data-row="${data.row}"][data-number="${data.number}"]`);

        // Если карточка существует, удаляем ее
        if (existingCard) {
            existingCard.parentElement.removeChild(existingCard);
        } else {
            // Если карточка не существует, создаем новую
            const ticketCardHtml = `
            <div class="ticket-cards__item ticket-cards__item-transition-enter-done" data-row="${data.row}" data-number="${data.number}">
                <div class="ticket-cards__row-place">Ряд ${data.row}, Место ${data.number}</div>
                <div class="ticket-cards__ticket-type"></div>
                <div class="ticket-cards__price">
                    <div class="ticket-cards__legend" style="background-color: rgb(0, 128, 0);"></div>
                    ${data.price} ₽
                </div>
                <img class="ticket-cards__close-button" src="/images/Popup__exit.png" alt="img">
            </div>
        `;

            const ticketCard = document.createElement('div');
            ticketCard.innerHTML = ticketCardHtml;

            if (ticketCardsContainer) {
                ticketCardsContainer.appendChild(ticketCard);

                // Добавляем обработчик события для удаления карточки
                const closeButton = ticketCard.querySelector('.ticket-cards__close-button');
                closeButton.addEventListener('click', function () {
                    ticketCardsContainer.removeChild(ticketCard);
                    const seat = document.querySelector(`.seat[data-row="${data.row}"][data-number="${data.number}"]`);
                    if (seat) {
                        seat.classList.remove("active");
                        document.querySelectorAll(".seat.disabled").forEach(s => s.classList.remove("disabled"));
                    }
                });
            } else {
                console.error("Container not found");
            }
        }
    };
});
