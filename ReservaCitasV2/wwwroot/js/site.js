// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(() => {
    let txtMsg = document.getElementById("txtMsg");
    txtMsg.addEventListener("keydown", (e) => {
        if (e.code == "Enter") {
            btnSend_Click();
        }
    })
})();

function alert(type = '', title = '', html = '') {
    let timer = 1500
    if (type === 'success') {
        timer = 5000
    }
    Swal.fire({
        icon: type,
        title,
        html,
        timer,
        timerProgressBar: true,
    }).then((result) => {
        if (result.dismiss === Swal.DismissReason.timer) {
            console.log('I was closed by the timer')
        }
    })
}

function reservaCita() {
    let pacienteNombre = document.getElementById("pacienteNombre");
    let pacienteSeguro = document.getElementById("pacienteSeguro");
    let lstEsp = document.getElementById("lstEsp");
    let lstDoc = document.getElementById("lstDoc");
    let txtDate = document.getElementById("txtDate");
    let lstHour = document.getElementById("lstHour");
    let fecha = `${txtDate.value.split('-')[2]}/${txtDate.value.split('-')[1]}/${txtDate.value.split("-")[0]}`
    let failed = false;
    if (lstEsp.value == '-1') failed = true;
    if (lstDoc.value == '-1') failed = true;
    if (lstHour.value == '-1') failed = true;
    if (failed) {
        let type = 'error';
        let title = '¡Faltan rellenar datos!';
        alert(type, title);
        return false;
    }
    let type = 'success';
    let title = '¡Reserva generada con exito!';
    head_class = 'text-start text-nowrap'
    value_class = 'text-start text-nowrap'
    let msg = `
    <div class="container w-75">
    <table class="table align-middle">
        <tbody>
            <tr>
                <td class="${head_class}">Paciente</td>
                <td class="${value_class}">${pacienteNombre.innerText}</td>
            </tr>
            <tr>
                <td class="${head_class}">Seguro</td>
                <td class="${value_class}">${pacienteSeguro.innerText}</td>
            </tr>
            <tr>
                <td class="${head_class}">Especialidad</td>
                <td class="${value_class}">${lstEsp.value}</td>
            </tr>
            <tr>
                <td class="${head_class}">Doctor</td>
                <td class="${value_class}">${lstDoc.value}</td>
            </tr>
            <tr>
                <td class="${head_class}">Fecha</td>
                <td class="${value_class}">${fecha}</td>
            </tr>
            <tr>
                <td class="${head_class}">Hora</td>
                <td class="${value_class}">${lstHour.value}</td>
            </tr>
        </tbody>
    </table>
    </div>
    `;

    let msg_IA = `
    <p class="text-white m-0 ps-2 pe-3 mb-1 text-wrap text-break">DATOS DE LA CITA</p>
    <table class="table align-middle">
        <tbody>
            <tr>
                <td class="${head_class}">Paciente</td>
                <td class="${value_class}">${pacienteNombre.innerText}</td>
            </tr>
            <tr>
                <td class="${head_class}">Seguro</td>
                <td class="${value_class}">${pacienteSeguro.innerText}</td>
            </tr>
            <tr>
                <td class="${head_class}">Especialidad</td>
                <td class="${value_class}">${lstEsp.value}</td>
            </tr>
            <tr>
                <td class="${head_class}">Doctor</td>
                <td class="${value_class}">${lstDoc.value}</td>
            </tr>
            <tr>
                <td class="${head_class}">Fecha</td>
                <td class="${value_class}">${fecha}</td>
            </tr>
            <tr>
                <td class="${head_class}">Hora</td>
                <td class="${value_class}">${lstHour.value}</td>
            </tr>
        </tbody>
    </table>
    `;
    alert(type, title, msg);
    addMsgBox("Perfecto, se ha generado la reserva con éxito.", 0, "left");
    addMsgBox(msg_IA, 0, 'left', 'table');
    addMsgBox("Recuerda asistir 30 minutos antes para realizar el pago de tu cita.", 0, "left");
    let lnkReprogramar = document.getElementById("lnkReprogramar");
    lnkReprogramar.click();
    let btnReprogramar_Cancelar = document.getElementById("btnReprogramar_Cancelar");
    btnReprogramar_Cancelar.click();
    return true;
}

function activarTab(tab = 0) {
    switch (tab) {
        case 1: {
            let lnkReserva = document.getElementById("lnkReserva");
            lnkReserva.click();
            break;
        }
        case 2: {
            let lnkReprogramar = document.getElementById("lnkReprogramar");
            lnkReprogramar.click();
            break;
        }
        case 3: {
            let lnkHistorial = document.getElementById("lnkHistorial");
            lnkHistorial.click();
            break;
        }
        default:
            break
    }
}

function reprogramarCita() {
    let pacienteNombre = document.getElementById("pacienteNombre");
    let pacienteSeguro = document.getElementById("pacienteSeguro");
    let lstEsp = document.getElementById("lstEspReprogramar");
    let lstDoc = document.getElementById("lstDocReprogramar");
    let txtDate = document.getElementById("txtDateReprogramar");
    let lstHour = document.getElementById("lstHourReprogramar");
    let fecha = `${txtDate.value.split('-')[2]}/${txtDate.value.split('-')[1]}/${txtDate.value.split("-")[0]}`
    let failed = false;
    if (lstEsp.value == '-1') failed = true;
    if (lstDoc.value == '-1') failed = true;
    if (lstHour.value == '-1') failed = true;
    if (failed) {
        let type = 'error';
        let title = '¡Faltan rellenar datos!';
        alert(type, title);
        return false;
    }
    let type = 'success';
    let title = '¡Cita reprogramada con exito!';
    head_class = 'text-start text-nowrap'
    value_class = 'text-start text-nowrap'
    let msg = `
    <div class="container w-75">
    <table class="table align-middle">
        <tbody>
            <tr>
                <td class="${head_class}">Paciente</td>
                <td class="${value_class}">${pacienteNombre.innerText}</td>
            </tr>
            <tr>
                <td class="${head_class}">Seguro</td>
                <td class="${value_class}">${pacienteSeguro.innerText}</td>
            </tr>
            <tr>
                <td class="${head_class}">Especialidad</td>
                <td class="${value_class}">${lstEsp.value}</td>
            </tr>
            <tr>
                <td class="${head_class}">Doctor</td>
                <td class="${value_class}">${lstDoc.value}</td>
            </tr>
            <tr>
                <td class="${head_class}">Fecha</td>
                <td class="${value_class}">${fecha}</td>
            </tr>
            <tr>
                <td class="${head_class}">Hora</td>
                <td class="${value_class}">${lstHour.value}</td>
            </tr>
        </tbody>
    </table>
    </div>
    `;

    let msg_IA = `
    <p class="text-white m-0 ps-2 pe-3 mb-1 text-wrap text-break">NUEVOS DATOS DE LA CITA</p>
    <table class="table align-middle">
        <tbody>
            <tr>
                <td class="${head_class}">Paciente</td>
                <td class="${value_class}">${pacienteNombre.innerText}</td>
            </tr>
            <tr>
                <td class="${head_class}">Seguro</td>
                <td class="${value_class}">${pacienteSeguro.innerText}</td>
            </tr>
            <tr>
                <td class="${head_class}">Especialidad</td>
                <td class="${value_class}">${lstEsp.value}</td>
            </tr>
            <tr>
                <td class="${head_class}">Doctor</td>
                <td class="${value_class}">${lstDoc.value}</td>
            </tr>
            <tr>
                <td class="${head_class}">Fecha</td>
                <td class="${value_class}">${fecha}</td>
            </tr>
            <tr>
                <td class="${head_class}">Hora</td>
                <td class="${value_class}">${lstHour.value}</td>
            </tr>
        </tbody>
    </table>
    `;
    alert(type, title, msg);
    addMsgBox(msg_IA, 0, 'left', 'table');
    let btnReprogramar_Cancelar = document.getElementById("btnReprogramar_Cancelar");
    btnReprogramar_Cancelar.click();
    return true;
}

function BuscarCita(tabla, input) {
    txtBuscar = document.getElementById(input.id);
    var table = document.getElementById(tabla);
    for (let row of table.getElementsByTagName("tr")) {
        for (let cell of row.getElementsByTagName("td")) {
            if (txtBuscar === "") {
                row.classList.remove("visually-hidden");
                continue;
            }
            if (cell.innerHTML.toUpperCase().includes(txtBuscar.value.toUpperCase())) {
                row.classList.remove("visually-hidden");
                break;
            } else {
                row.classList.add("visually-hidden");
            }
        }
    }
}

function scrollContentToBottom(element) {
    element.scrollTop = element.scrollHeight;
}

function addMsgBox(text = "", id = 0, side = "left", type = 'text') {
    if (text == "") {
        return;
    }
    if (text.includes('Adrián')) {
        text = 'Alo adrian herrera cou'
    }
    if (text.includes('doctor Monroy')) {
        text = 'Quisiera sacar una cita con el Doctor Monrroy en la especialidad de TRAUMATOLOGIA'
    }
    if (text.includes('La primera está bien.')) {
        text = 'la primera fecha esta bien'
    }
    let color = side == "right" ? "bg-primary" : "bg-secondary";
    let msg_class = `d-flex text-wrap justify-content-end align-items-center msg_box msg_box_${side} ${color}`
    let msg_container = document.createElement("div");
    msg_container.id = `chat_${side}_${id}`;
    let speechIA = false;
    if (side === "right") {
        msg_container.setAttribute("style", `margin-right: 10px;`);
    } else if (side === "left") {
        msg_container.setAttribute("style", `margin-left: 10px;`);
        speechIA = true;
    }
    if (type === 'text') {
        msg_container.innerHTML = `<p class="text-white m-0 ps-2 pe-3 text-wrap text-break">${text}</p>`;
    } else {
        msg_class = `d-flex flex-column text-wrap justify-content-start align-items-start msg_box msg_box_${side} ${color}`
        msg_container.innerHTML = `${text}`;
        speechIA = false;
    }
    if (speechIA) {
        speechText(text);
    }

    msg_container.setAttribute("class", msg_class);
    let chat_container = document.getElementById("chat_container");
    chat_container.appendChild(msg_container);
    scrollContentToBottom(chat_container);
}

function btnSend_Click() {
    let btnSend = document.getElementById("btnSend");
    let txtMsg = document.getElementById("txtMsg");
    let msg = txtMsg.value;
    addMsgBox(msg, 0, "right");
    respuestaIA(msg);
    txtMsg.value = "";
}

function respuestaIA(text = '') {
    if (text == '') {
        return 0;
    }
    if (text.includes('Adrián')) {
        text = 'Alo adrian herrera cou'
    }
    if (text.includes('doctor Monroy')) {
        text = 'quisiera sacar una cita con el doctor monrroy en la especialidad de traumatologia'
    }
    if (text.includes('La primera está bien.')) {
        text = 'la primera fecha esta bien'
    }
    function searchElement(e, list) {
        for (let i of list) {
            if (i.toLowerCase() == e) {
                return true;
            }
        }
    }
    text = text.replaceAll('.', '');
    text = text.toLowerCase();
    let dspReserva = ["Reservar cita", "Quisiera Reservar cita", "Quisiera Reservar una cita", "Reservar una cita", "Sacar una cita", "Quisiera Sacar cita", "Quisiera Sacar una cita", "Crear cita"];
    let dspRePro = ["Reprogramar cita", "Quisiera Reprogramar cita", "Quisiera Reprogramar una cita", "Reprogramar una cita"];
    let dspHist = ["Ver mi historial de citas", "historial de citas", "registro de citas", "Quiero ver mi historial de citas", "Quiero ver mis citas pasadas"];
    let dspSaludo = ["Hola", "Buenos dias", "Buenas Tardes", "Buenas Noches", "Buenas", "Hi"];
    let dspAgradecimiento = ["Gracias", "Muchas gracias", "Eh gracias"];
    if (searchElement(text, dspSaludo)) {
        addMsgBox("Hola, ¿En que puedo ayudarte hoy?", 0, "left");
        return 0;
    }
    if (searchElement(text, dspReserva)) {
        addMsgBox("Claro, ¿Deseas atenderte con algún médico o en una fecha en especial?", 0, "left");
        activarTab(1)
        return 0;
    }
    if (searchElement(text, dspRePro)) {
        addMsgBox("Claro, ¿Que cita deseas reprogramar?", 0, "left");
        addMsgBox("Dictame el codigo para llevarte a ella.", 0, "left");
        activarTab(2)
        return 0;
    }
    if (searchElement(text, dspHist)) {
        addMsgBox("Claro, este es tu historial de citas ¿Deseas ver el detalle de alguna en particular?", 0, "left");
        addMsgBox("Dictame el codigo para llevarte a ella.", 0, "left");
        activarTab(3)
        return 0;
    }
    if (searchElement(text, dspAgradecimiento)) {
        addMsgBox("De nada, un gusto ayudarte", 0, "left");
        return 0;
    }
    console.log(text)
    if (text == 'quisiera sacar una cita con el doctor monrroy en la especialidad de traumatologia') {
        let lstEsp = document.getElementById("lstEsp");
        let lstDoc = document.getElementById("lstDoc");
        lstEsp.value = 'TRAUMATOLOGIA';
        lstDoc.value = 'Dr. Monrroy';
        addMsgBox("Claro, a continuación te muestro las fechas más cercanas disponibles", 0, "left");
        addMsgBox("Sábado 28, 07:30", 0, "left");
        addMsgBox("Sábado 28, 09:00", 0, "left");
        addMsgBox("¿Para cuando deseas reservar tu cita?", 0, "left");
        return 0;
    }

    if (text == 'la primera fecha esta bien') {
        let txtDate = document.getElementById("txtDate");
        let lstHour = document.getElementById("lstHour");
        txtDate.value = '2023-10-28';
        lstHour.value = '07:30';
        reservaCita()
        return 0;
    }

    if (text == 'alo adrian herrera cou') {
        addMsgBox("Hola brazos de 35, ¿En que puedo ayudarte hoy?", 0, "left");
        addMsgBox("Que no sea en estetica porque ahi vas salir perdiendo maquina", 0, "left");
        return 0;
    }
}

function btnReprogramar_Click() {
    let tabReprogramar1 = document.getElementById("tabReprogramar1");
    let tabReprogramar2 = document.getElementById("tabReprogramar2");
    tabReprogramar1.classList.add("visually-hidden");
    tabReprogramar2.classList.remove("visually-hidden");
}


function reprogramarCita_Cancelar() {
    let tabReprogramar1 = document.getElementById("tabReprogramar1");
    let tabReprogramar2 = document.getElementById("tabReprogramar2");
    tabReprogramar1.classList.remove("visually-hidden");
    tabReprogramar2.classList.add("visually-hidden");
}

function btnVerDetalles_Historial_Click() {
    let tabHistorial1 = document.getElementById("tabHistorial1");
    let tabHistorial2 = document.getElementById("tabHistorial2");
    tabHistorial1.classList.add("visually-hidden");
    tabHistorial2.classList.remove("visually-hidden");
}
function historialCita_Cancelar() {
    let tabHistorial1 = document.getElementById("tabHistorial1");
    let tabHistorial2 = document.getElementById("tabHistorial2");
    tabHistorial1.classList.remove("visually-hidden");
    tabHistorial2.classList.add("visually-hidden");
}

function btnReprogramarCancelar_Click(text = '') {
    if (text == '') {
        return 0;
    }
    row = document.getElementById(text)
    row.classList.add("visually-hidden");
}

function updLinkColor(obj) {
    textColor = "fw-bold"
    lnkReserva = document.getElementById("lnkReserva");
    lnkReprogramar = document.getElementById("lnkReprogramar")
    lnkHistorial = document.getElementById("lnkHistorial")
    tabReserva = document.getElementById("tabReserva");
    tabReprogramar = document.getElementById("tabReprogramar");
    tabHistorial = document.getElementById("tabHistorial");
    tab_tittle = document.getElementById("tab_tittle");
    lnkReserva.classList.remove(textColor)
    lnkReprogramar.classList.remove(textColor)
    lnkHistorial.classList.remove(textColor)

    switch (obj.id) {
        case "lnkReserva":
            {
                tabReserva.classList.remove("visually-hidden")
                tabReprogramar.classList.add("visually-hidden")
                tabHistorial.classList.add("visually-hidden")
                tab_tittle.innerHTML = "Reserva de Cita";
                break;
            }
        case "lnkReprogramar":
            {
                tabReprogramar.classList.remove("visually-hidden")
                tabReserva.classList.add("visually-hidden")
                tabHistorial.classList.add("visually-hidden")
                tab_tittle.innerHTML = "Reprogramación de Cita";
                let tabReprogramar1 = document.getElementById("tabReprogramar1");
                let tabReprogramar2 = document.getElementById("tabReprogramar2");
                tabReprogramar1.classList.remove("visually-hidden");
                tabReprogramar2.classList.add("visually-hidden");
                break;
            }
        case "lnkCancelar":
            {
                tabCancelar.classList.remove("visually-hidden")
                tabReprogramar.classList.add("visually-hidden")
                tabHistorial.classList.add("visually-hidden")
                tab_tittle.innerHTML = "Reserva de Cita";
                break;
            }
        case "lnkHistorial":
            {
                tabHistorial.classList.remove("visually-hidden")
                tabReprogramar.classList.add("visually-hidden")
                tabReserva.classList.add("visually-hidden")
                tab_tittle.innerHTML = "Historial de Citas";
                break;
            }
        default:
            console.log("ERROR")
            break;
    }

    obj.classList.add(textColor);
}

let is_VoiceOn = false;

function speechText(text = '') {
    if (text == '') {
        return 0;
    }
    const utterance = new SpeechSynthesisUtterance();
    utterance.lang = "es-ES";
    utterance.voice = speechSynthesis.getVoices()[0];
    utterance.volume = 1;
    utterance.rate = 1;
    utterance.pitch = 1;
    utterance.text = text;
    speechSynthesis.speak(utterance);
}

(() => {
    if ("webkitSpeechRecognition" in window) {
        let speechRecognition = new webkitSpeechRecognition();

        let final_transcript = "";

        speechRecognition.continuous = true;
        speechRecognition.interimResults = true;
        speechRecognition.lang = 'es-PE';

        speechRecognition.onstart = () => {
            is_VoiceOn = true;
            console.log("Speech Recognition Started")
        };
        speechRecognition.onerror = () => {
            console.log("Speech Recognition Error")
        };
        speechRecognition.onend = () => {
            is_VoiceOn = false;
            console.log("Speech Recognition Stopped")
        };

        speechRecognition.onresult = (event) => {
            let interim_transcript = "";
            for (let i = event.resultIndex; i < event.results.length; ++i) {
                if (event.results[i].isFinal) {
                    final_transcript += event.results[i][0].transcript;
                } else {
                    interim_transcript += event.results[i][0].transcript;
                }
            }
            console.log(final_transcript);
            addMsgBox(final_transcript, 0, 'right', 'text');
            respuestaIA(final_transcript);
            final_transcript = ''
        };
        document.onkeydown = (e) => {
            if (e.repeat) {
                return 0;
            }
            console.log(e);
            if (e.code == 'ControlLeft') {
                speechRecognition.start();
                final_transcript = ''
            }
        }
        document.addEventListener("keyup", (e) => {
            console.log(e);
            console.log(final_transcript);
            if (e.code == 'ControlLeft') {
                speechRecognition.stop();
                final_transcript = ''
                return;
            }
        });
        document.querySelector("#btnVoice").onclick = () => {
            if (is_VoiceOn) {
                is_VoiceOn = false;
                speechRecognition.stop();
                addMsgBox(final_transcript, 0, 'right', 'text');
                respuestaIA(final_transcript);
                final_transcript = ''
                return;
            }
            speechRecognition.start();
            is_VoiceOn = true;
            final_transcript = ''
        };
        //txtMsg.addEventListener("keydown", (e) => {
        //    if (e.code == "Enter") {
        //        btnSend_Click();
        //})
    } else {
        console.log("Speech Recognition Not Available")

    }
})();