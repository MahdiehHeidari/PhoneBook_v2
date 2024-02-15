// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addPhoneNumber() {
    var newIndex = document.querySelectorAll('#phoneContainer input').length;

    var phoneInput = document.createElement('input');
    phoneInput.type = 'text';
    phoneInput.name = 'Phones[' + newIndex + '].PhoneNumber';
    phoneInput.placeholder = 'شماره تلفن';

    var typeSelect = document.createElement('select');
    typeSelect.name = 'Phones[' + newIndex + '].Type';
    typeSelect.placeholder = 'لطفا نوع تلفن را وارد کنید '

    var homeOption = document.createElement('option');
    homeOption.value = '-1';
    homeOption.text = 'نوع تلفن را وارد کنید';
    homeOption.selected = true;


    typeSelect.appendChild(homeOption);

    var homeOption = document.createElement('option');
    homeOption.value = '0';
    homeOption.text = 'خانه';
    typeSelect.appendChild(homeOption);



    var mobileOption = document.createElement('option');
    mobileOption.value = '1';
    mobileOption.text = 'محل کار';
    typeSelect.appendChild(mobileOption);

    var mobileOption = document.createElement('option');
    mobileOption.value = '2';
    mobileOption.text = 'موبایل';
    typeSelect.appendChild(mobileOption);

    typeSelect.selectedIndex = -1;
    typeSelect.value = -1;


    var constraintMessage = document.createElement('span');
    constraintMessage.style.color = 'red'; // رنگ قرمز برای نمایش پیام خطا
    var br = document.createElement('br');

    // var deleteIcon = document.createElement('span');
    // deleteIcon.innerHTML = 'x';

    document.getElementById('phoneContainer').appendChild(phoneInput);
    document.getElementById('phoneContainer').appendChild(typeSelect);
    document.getElementById('phoneContainer').appendChild(constraintMessage);
    //document.getElementById('phoneContainer').appendChild(deleteIcon);
    document.getElementById('phoneContainer').appendChild(br);

    // deleteIcon.addEventListener('click',
    //    function () {
    //        alert(2323);
    //        document.getElementById('phoneContainer').parentNode.removeChild(document.getElementById('phoneContainer'));
    //    }
    //  );

}