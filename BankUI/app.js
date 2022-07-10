const uri = 'http://localhost:12885/api/Accounts'; 

function getAccounts() {
  fetch(uri)
    .then(response => response.json())
    .then(data => displayAccounts(data))
    .catch(error => console.error('Unable to get accounts details.', error));    
}

function displayAccounts(data) {
    let tab = 
        ` <tr>
        <th>Account Number</th>
        <th>First Name</th>
        <th>Last Name</th>
        <th>Phone Number</th>
        <th>Email</th>
        <th>Current Balance</th>
    </tr>`;
    
    // Loop to access all rows 
    for (let r of data) {
        tab += `<tr>     
    <td><input type="button" value=${r.accountNumber} onclick="navigateTransactions(this.value)"> </td>     
    <td>${r.firstName}</td>
    <td>${r.lastName}</td> 
    <td>${r.phoneNumber}</td>    
    <td>${r.email}</td>      
    <td>${r.currentAccountBalance}</td>   
</tr>`;
    }
    // Setting innerHTML as tab variable
    document.getElementById("accounts").innerHTML = tab;
}

function navigateTransactions(accountNo)
{
    const tranUrl = 'http://localhost:64332/api/Transactions/' + accountNo;  
    sessionStorage.setItem("transactionURL", tranUrl);
    location.href="transactions.html";
}

function addAccounts() {
    const txtFirstName = document.getElementById("txtFirstName");
    const txtLastName = document.getElementById("txtLastName");
    const txtPhoneNumber = document.getElementById("txtPhoneNumber");
    const txtEmail = document.getElementById("txtEmail");
    const txtCurrentBalance = document.getElementById("txtCurrentBalance");
    
    const item = {
      firstName: txtFirstName,
      lastName: txtLastName,
      phoneNumber: txtPhoneNumber,
      email:txtEmail, 
      dateCreated: "2022-07-10",
      currentAccountBalance:txtCurrentBalance
    }; 

  fetch(uri, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
    getAccounts();     
    })
    .catch(error =>console.log(error));
}

