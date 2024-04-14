const hostname = "http://localhost:5000";
const nameInput = $("#name");
const surnameInput = $("#surname");
const ageInput = $("#age");
const messageInput = $("#message");
const usernameInput = $("#username");
const passwordInput = $("#password");
const isVolunteerInput = $("#volunteer");

async function submitForm(event) {
  const name = nameInput.val();
  const surname = surnameInput.val();
  const username = usernameInput.val();
  const age = ageInput.val();
  const password = passwordInput.val();
  const isVolunteer = isVolunteerInput.is(":checked");

  try {
    const response = await fetch(hostname + "/Users/Create", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        isVolontier: isVolunteer, // isVolontier is the name of the model property
        name: name,
        surname: surname,
        username: username,
        age: age,
        password: password,
      }),
    });

    if (!response.ok) {
      throw new Error("Failed to register user.");
    }

    const data = await response.json();
    console.log("User registered successfully:", data);
    localStorage.setItem("user", JSON.stringify(data));

    nameInput.val("");
    surnameInput.val("");
    usernameInput.val("");
    ageInput.val("");
    passwordInput.val("");

    window.location.pathname = "/index.html";
  } catch (error) {
    console.error("Error registering user:", error);
  }
}
