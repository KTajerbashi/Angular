let data = localStorage.getItem("Data");

if (data) {
    // Process and display the data
    let dataList = JSON.parse(data);
    dataList.forEach((user,index) => {
        const li = document.createElement("li");
        li.textContent = `${index + 1} : ${user.name} (${user.email})`;
        userList.appendChild(li);
    });
} else {
    console.log("No data found in localStorage.");
}