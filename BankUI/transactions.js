const accountNo = document.getElementById("transactions").innerHTML = tab;

function getTransactions() {
    var uri = sessionStorage.getItem("transactionURL");
  fetch(uri)
    .then(response => response.json())
    .then(data => displayTransactions(data))
    .catch(error => console.error('Unable to get transaction details.', error));    
}

function displayTransactions(data) {
    let tab = 
        ` <tr>
        <th>Transaction Amount</th>
        <th>Transaction Status</th>
        <th>TransactionDescription</th>
        <th>Transaction Date</th>    
        <th>Total Amount</th>   
    </tr>`;    
    // Loop to access all rows 
    for (let r of data) {
        tab += `<tr> 
    <td>${r.transactionAmount} </td>
    <td>${r.transactionStatus}</td>
    <td>${r.transactionDescription}</td>       
    <td>${r.transactionDate}</td> 
    <td>${r.currentTotalAmount}</td>      
      
</tr>`;
    }
    // Setting innerHTML as tab variable
    document.getElementById("transactions").innerHTML = tab;
}
