
// Set up SignalR connection
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/onlineUsers")
    .build();

// Listen for the broadcast event from the server
connection.on("OnlineUsersUpdated", function () {
    console.log("Broadcast received. Fetching online users...");
    fetchOnlineUsers();
});

// Start the SignalR connection
connection.start()
    .then(() => console.log("SignalR connected"))
    .catch(err => console.error("SignalR connection error:", err));

// Function to fetch online users from the API
async function fetchOnlineUsers() {
    try {
        const response = await fetch("/api/User/onlineUsers");
        const users = await response.json();

        const userList = document.getElementById("userList");
        userList.innerHTML = ""; // Clear current list

        users.data.forEach((user, index) => {
            const li = document.createElement("ol");
            li.textContent = `${index + 1}:  (${user.userName})`;
            userList.appendChild(li);
        });
    } catch (error) {
        console.error("Failed to fetch online users:", error);
    }
}

// Broadcast button click event
document.getElementById("broadcastButton").addEventListener("click", function () {
    connection.invoke("NotifyOnlineUsersUpdated")
        .catch(err => console.error("Error invoking broadcast:", err));
});

// Initial fetch of online users
setInterval(() => {
    fetchOnlineUsers();
},5000);



