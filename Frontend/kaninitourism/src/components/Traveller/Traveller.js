import React, { useState } from "react";
import "../Traveller/Traveller.css";
import { Route, Routes, useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import { AiOutlineMenu } from "react-icons/ai";
import { MdCancel } from "react-icons/md";
import UserHome from "../UserHome/UserHome";
import Package from "../Packages/Package";
import TourPackage from "../TourPackage/TourPackage";
import Booking from "../Booking/Booking";
import BookingView from "../BookingView/BookingView";

function Traveller() {
  const [toggleDropDown, setDropDown] = useState(false);
  const navigate = useNavigate();
  return (
    <div className="Traveller">
      <div className="Navbar">
        <header className="NavbarHeader">
          <div className="navbar">
            <div className="logo">
              <Link to="/" className="link logoLink">
                <h2 className="MakeYourTripLogo">MakeYourTrip</h2>
              </Link>
            </div>
            <ul className="links">
              <li className="navButton">
                <Link className="link" to="/traveller">
                  Home
                </Link>
              </li>
              <li className="navButton">
                <Link className="link" to="tourpackages/">
                  Tour Packages
                </Link>
              </li>
              <li className="navButton">
                <Link className="link" to="/login">
                  Profile
                </Link>
              </li>
              <li className="navButton">
                <Link className="link" to="/traveller/userbooking">
                  View Bookings
                </Link>
              </li>
            </ul>
            <button
              onClick={() => {
                localStorage.clear();
                navigate("/home");
              }}
              className="action_btn link"
            >
              Logout
            </button>
            <div
              className="toggle_btn"
              onClick={() => {
                setDropDown(!toggleDropDown);
              }}
            >
              {toggleDropDown ? (
                <MdCancel className="agentNavMenuOption" />
              ) : (
                <AiOutlineMenu className="agentNavMenuOption" />
              )}
            </div>
          </div>
          <div
            className={toggleDropDown ? "dropdown_menu open" : "dropdown_menu"}
          >
            <li>
              <Link className="link" to="/">
                Home
              </Link>
            </li>
            <li className="">
              <Link className="link" to="/tourpackages">
                TourPackages
              </Link>
            </li>
            <li>
              <Link className="link" to="/login">
                Profile
              </Link>
            </li>
            <li>
              <Link className="link" to="/traveller/userbooking">
                View Bookings
              </Link>
            </li>
            <li>
              <button
                onClick={() => {
                  localStorage.clear();
                  navigate("/home");
                }}
                className="action_btn link"
              >
                Logout
              </button>
            </li>
          </div>
        </header>
      </div>
      <div className="TravellerContentDetails">
        <div>
          <Routes>
            <Route path="/" element={<UserHome />} />
            <Route path="/tourpackages" element={<Package />} />
            <Route path="/packagedetails/:id" element={<TourPackage />} />
            <Route path="/booking" element={<Booking />} />
            <Route path="/userbooking" element={<BookingView />} />
          </Routes>
        </div>
      </div>
    </div>
  );
}

export default Traveller;
