const hostname = 'http://localhost:5000'
const nameInput = $('#name')
const surnameInput = $('#surname')
const ageInput = $('#age')
const messageInput = $('#message')

function submitForm(event) {
    event.preventDefault();

    const name = nameInput.val()
    const surname = surnameInput.val()
    const age = ageInput.val()
    const message = messageInput.val()

    $.ajax(hostname + '/Tickets/Test', {
        method: 'POST',
        dataType: 'json',
        data: {
            'submitter': name + surname,
            'description': message
        },
        error: (err) => {
            console.error(err);
            console.log(err.getAllResponseHeaders())
        },
        success: (response) => {
            console.log(response)

            nameInput.val('')
            surnameInput.val('')
            ageInput.val('')
            messageInput.val('')
        }
    });

    
    
}