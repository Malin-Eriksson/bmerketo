try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function () {
        const element = document.querySelector(toggleBtn.getAttribute('data-target'))

        if (!element.classList.contains('open-menu')) {
            element.classList.add('open-menu')
            toggleBtn.classList.add('btn-outline-dark')
            toggleBtn.classList.add('btn-toggle-white')
        }

        else {
            element.classList.remove('open-menu')
            toggleBtn.classList.remove('btn-outline-dark')
            toggleBtn.classList.remove('btn-toggle-white')
        }
    })
} catch { }


try {
    const footer = document.querySelector('footer')

    if (document.body.scrollHeight >= window.innerHeight + footer.scrollHeight) {
        footer.classList.remove('position-fixed-bottom')
        footer.classList.add('position-static')
    } else {
        footer.classList.remove('position-static')
        footer.classList.add('position-fixed-bottom')
    }
} catch { }



// validation
const validateText = (event) => {
    if (event.target.value.length >= 2) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    } else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "invalid length"
    }      
    
}

const validateEmail = (event) => {

    const regEx = /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/

    if (regEx.test(event.target.value)) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    } else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "invalid email address"
    }
}

const validatePassword = (event) => {

    const regEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/

    if (regEx.test(event.target.value)) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    } else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "invalid password"
    }
}





