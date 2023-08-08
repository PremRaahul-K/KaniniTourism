import React, { useEffect, useState } from "react";
import "../BookingView/BookingView.css";
import Footer from "../Footer/Footer";

function BookingView() {
  const [userData, setUserData] = useState([]);
  const [userIdDTO, setUserIdDTO] = useState({
    userId: 0,
  });

  useEffect(() => {
    const userIdLocal = parseInt(localStorage.getItem("id"), 10);
    setUserIdDTO({
      userId: userIdLocal,
    });
  }, []);

  useEffect(() => {
    if (userIdDTO.userId !== 0) {
      fetch("http://localhost:5011/api/Booking/GetBookingWithUserId", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userIdDTO),
      })
        .then(async (response) => {
          if (response.ok) {
            const data = await response.json();
            setUserData(data);
          } else {
            console.log("Error fetching data");
          }
        })
        .catch((err) => {
          console.log("Fetch error:", err);
        });
    }
  }, [userIdDTO]);

  return (
    <div className="BookingView">
      <table className="table">
        <thead>
          <tr>
            <th>Booking Id</th>
            <th>Contact Name</th>
            <th>Total Price</th>
            <th>Booking Status</th>
          </tr>
        </thead>
        <tbody>
          {userData.map((item, index) => (
            <tr key={index}>
              <td data-label="Booking Id">{item.bookingId}</td>
              <td data-label="Contact Name">{item.contactName}</td>
              <td data-label="Total Price">{item.totalPrice}</td>
              <td data-label="Booking Status">{item.bookingStatus}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <div>
        <Footer />
      </div>
    </div>
  );
}

export default BookingView;
