import React, { useState } from "react";
import "../Traveller/Traveller.css";
import { Route, Routes } from "react-router-dom";
import { Link } from "react-router-dom";
import { AiOutlineMenu } from "react-icons/ai";
import { MdCancel } from "react-icons/md";
import UserHome from "../UserHome/UserHome";
import Package from "../Packages/Package";

function Traveller() {
  const [toggleDropDown, setDropDown] = useState(false);
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
                  View Bookings
                </Link>
              </li>
            </ul>
            <Link to="" className="action_btn link">
              Profile
            </Link>
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
                View Bookings
              </Link>
            </li>
            <li>
              <Link to="/login" className="action_btn link">
                Profile
              </Link>
            </li>
          </div>
        </header>
      </div>
      <div className="TravellerContent">
        <Routes>
          <Route path="/" element={<UserHome />} />
          <Route path="/tourpackages" element={<Package />} />
        </Routes>
      </div>
    </div>
  );
}

export default Traveller;
