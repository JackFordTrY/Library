const notification = document.querySelector(".notification");

const notificationMessage = document.querySelector("#notification-text")

const notificate = notificationFunction();

function notificationFunction()
{
	let block = false;

	return (text) => {
		console.log(block);
		if (!block) {

			block = true;

			notificationMessage.innerHTML = text;

			notification.classList.toggle("hidden");

			setTimeout(() => {
				notification.classList.toggle("hidden");

				block = false;
			},1000);
		}
	}
}