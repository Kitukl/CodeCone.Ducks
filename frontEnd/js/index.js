const hostname = "http://localhost:5000";
const nameInput = $("#name");
const surnameInput = $("#surname");
const ageInput = $("#age");
const messageInput = $("#message");
const usernameInput = $("#username");

function submitForm(event) {
  const name = nameInput.val();
  const surname = surnameInput.val();
  const age = ageInput.val();
  const message = messageInput.val();
  const user = JSON.parse(localStorage.getItem("user"));

  $.ajax(hostname + "/Tickets/Create", {
    method: "POST",
    dataType: "json",
    processData: false,
    contentType: "application/json",
    data: JSON.stringify({
      description: message,
      title: "title",
      createdAt: new Date(),
      ticketId: 0,
      userId: user.id,
    }),
    error: (err) => {
      console.error(err);
    },
    success: (response) => {
      console.log(response);

      nameInput.val("");
      surnameInput.val("");
      ageInput.val("");
      messageInput.val("");
    },
  });
}
