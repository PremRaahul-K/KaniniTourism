import { useEffect } from "react";
import React, { useState } from "react";
import "../ViewAgents/ViewAgents.css";

function ViewAgents() {
  const [userData, setUserData] = useState([]);
  useEffect(() => {
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
  }, []);
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
                  className={
                    item.status == "Not Approved"
                      ? "approveButton"
                      : "notApproveButton"
                  }
                >
                  {item.status == "Approved" ? "Disapprove" : "Approve"}
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
