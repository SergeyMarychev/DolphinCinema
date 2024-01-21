const toast = (status, title, message) => {
    const element = document.createElement("div");
    element.className = "toast";

    let icon = "";
    switch (status) {
        case "error":
            icon = '<i class="toast-status fa-regular fa-circle-xmark error"></i>';
            break;
        case "info":
            icon = '<i class="toast-status fa-solid fa-info info"></i>';
            break;
        case "success":
            icon = '<i class="toast-status fa-regular fa-circle-check success"></i>';
            break;
        case "warning":
            icon = '<i class="toast-status fa-solid fa-exclamation warning"></i>';
            break;
    }

    element.innerHTML = `
        <div class="toast-header">
            <div class="toast-icon">${icon}
                <div class="toast-title">${title}</div>
            </div>
            <div class="toast-close">
                <button type="button" class="toast-button">
                    <img class="toast-img" src="/images/Popup__exit.png" alt="Закрыть"/>
                </button>
            </div>
        </div>
        <div class="toast-body">${message}</div>`;

    const closeButton = element.querySelector('.toast-button');
    closeButton.addEventListener('click', () => {
        element.remove();
    });

    document.querySelector("body").appendChild(element);

    setTimeout(() => {
        element.remove();
    }, 5000);
}

export default toast;