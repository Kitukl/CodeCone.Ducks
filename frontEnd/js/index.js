const hostname = "http://localhost:5000";
const nameInput = $("#name");
const surnameInput = $("#surname");
const ageInput = $("#age");
const messageInput = $("#message");
const usernameInput = $("#username");

document.addEventListener("DOMContentLoaded", function (event) {
  loadTickets();
});

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

function loadTickets() {
  $.ajax(hostname + "/Tickets", {
    method: "GET",
    dataType: "json",
    processData: false,
    contentType: "application/json",
    error: (err) => {
      console.error(err);
    },
    success: (response) => {
      renderTickets(response);
    },
  });
}

// Function to dynamically generate HTML for each ticket
function generateTicketHTML(ticket) {
  return `
        <div class="ticket">
            <h3>${ticket.title}</h3>
            <p>Description: ${ticket.description}</p>
            <p>Created At: ${ticket.createdAt}</p>
            <div class="ticket-button">
                <button>Resolve</button>
            </div>
        </div>
    `;
}

// Function to render tickets
function renderTickets(tickets) {
  var ticketList = document.getElementById("ticketList");
  ticketList.innerHTML = ""; // Clear previous content

  // Loop through tickets and append HTML to ticketList
  tickets.forEach(function (ticket) {
    ticketList.innerHTML += generateTicketHTML(ticket);
  });
}

// Call renderTickets to display tickets initially
// renderTickets();
