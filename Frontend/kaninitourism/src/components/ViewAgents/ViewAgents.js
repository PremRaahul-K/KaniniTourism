import { useEffect } from "react";
import React, { useState } from "react";
import "../ViewAgents/ViewAgents.css";

function ViewAgents() {
  const [userData, setUserData] = useState([]);
  useEffect(() => {
    GetAllTravelAgents();
  });
  const GetAllTravelAgents = () => {
    fetch("http://localhost:5115/api/TravelAgent/GetAllTravelAgents", {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
    })
      .then(async (response) => {
        if (response.ok) {
          const data = await response.json();
          console.log(data);
          setUserData(data);
        } else {
          console.log("Error fetching data");
        }
      })
      .catch((err) => {
        console.log("Fetch error:", err);
      });
  };

  var ChangeStatus = (data) => {
    var token = localStorage.getItem("token");
    fetch("http://localhost:5115/api/TravelAgent/UpdateTravelAgentStatus", {
      method: "PUT",
      headers: {
        accept: "text/plain",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then(async (data) => {
        var myData = await data.json();
        GetAllTravelAgents();
        alert("success");
      })
      .catch((err) => {
        console.log(err.error);
      });
  };
  return (
    <div>
      <table className="table">
        <thead>
          <tr>
            <th>Agent Id</th>
            <th>Agent Name</th>
            <th>Agency Name</th>
            <th>Status</th>
            <th>Update Status</th>
          </tr>
        </thead>
        <tbody>
          {userData.map((item, index) => (
            <tr key={index}>
              <td data-label="Agent Id">{item.userId}</td>
              <td data-label="Agent Name">{item.firstName}</td>
              <td data-label="Agency Name">{item.travelAgent.agencyName}</td>
              <td data-label="status">{item.travelAgent.status}</td>
              <td data-label="Update Status">
                <button
                  onClick={() => {
                    var userStatus =
                      item.travelAgent.status == "Approved"
                        ? "Not Approved"
                        : "Approved";
                    ChangeStatus({
                      userId: item.userId,
                      status: userStatus,
                    });
                  }}
                  className={
                    item.travelAgent.status == "Approved"
                      ? "notApproveButton"
                      : "approveButton"
                  }
                >
                  {item.travelAgent.status == "Approved"
                    ? "Disapprove"
                    : "Approve"}
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ViewAgents;
