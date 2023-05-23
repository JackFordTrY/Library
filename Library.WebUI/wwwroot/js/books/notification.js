const notification = document.querySelector(".notification");

const notificationMessage = document.querySelector("#notification-text")

const notificate = notificationFunction();

function notificationFunction()
{
	let block = false;

	return (text, isGood) => {
		if (!block) {

			block = true;

			notificationMessage.innerHTML = text;

			notification.classList.toggle("hidden");

			if (isGood) {
				goodNtf();
			}
			else {
				badNtf();
			}

			setTimeout(() => {
				notification.classList.toggle("hidden");

				block = false;
			},1000);
		}
	}
}

function goodNtf() {
	notification.classList.toggle("ntf-good");
	setTimeout(() => {
		notification.classList.toggle("ntf-good");
	}, 1000);
}

function badNtf() {
	notification.classList.toggle("ntf-danger");
	setTimeout(() => {
		notification.classList.toggle("ntf-danger");
	}, 1000);
}