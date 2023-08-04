import React, { useState } from "react";
import "../Navbar/Navbar.css";
import { Link } from "react-router-dom";
import TourismLogo from "../images/TravellerImage.png";

function Navbar() {
  const [toggleDropDown, setDropDown] = useState(false);
  return (
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
              <Link className="link" to="/login">
                Home
              </Link>
            </li>
            <li className="navButton">
              <Link className="link" to="/login">
                About
              </Link>
            </li>
            <li className="navButton">
              <Link className="link" to="/login">
                Services
              </Link>
            </li>
            <li className="navButton">
              <Link className="link" to="/login">
                Contact
              </Link>
            </li>
          </ul>
          <Link to="/login" className="action_btn link">
            GetStarted
          </Link>
          <div
            className="toggle_btn"
            onClick={() => {
              setDropDown(!toggleDropDown);
            }}
          >
            <i
              class={
                toggleDropDown ? "bi bi-x menuOption" : "bi bi-list menuOption"
              }
            ></i>
          </div>
        </div>
        <div
          className={toggleDropDown ? "dropdown_menu open" : "dropdown_menu"}
        >
          <li className="">
            <Link className="link" to="/login">
              Home
            </Link>
          </li>
          <li>
            <Link className="link" to="/login">
              About
            </Link>
          </li>
          <li>
            <Link className="link" to="/login">
              Services
            </Link>
          </li>
          <li>
            <Link className="link" to="/login">
              Contact
            </Link>
          </li>
          <li>
            <Link to="/login" className="action_btn link">
              GetStarted
            </Link>
          </li>
        </div>
      </header>
    </div>
  );
}

export default Navbar;
