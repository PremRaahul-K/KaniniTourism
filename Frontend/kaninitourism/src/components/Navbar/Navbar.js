import React, { useState } from "react";
import "../Navbar/Navbar.css";
import { Link } from "react-router-dom";
import TourismLogo from "../images/TravellerImage.png";
import { AiOutlineMenu } from "react-icons/ai";
import { MdCancel } from "react-icons/md";

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
              <Link className="link" to="/home">
                Home
              </Link>
            </li>
            <li className="navButton">
              <Link className="link" to="/about">
                About
              </Link>
            </li>
          </ul>
          <Link to="/login" className="action_btn link">
            Login
          </Link>
          <div
            className="toggle_btn"
            onClick={() => {
              setDropDown(!toggleDropDown);
            }}
          >
            {toggleDropDown ? (
              <MdCancel className="menuOption" />
            ) : (
              <AiOutlineMenu className="menuOption" />
            )}
          </div>
        </div>
        <div
          className={toggleDropDown ? "dropdown_menu open" : "dropdown_menu"}
        >
          <li className="">
            <Link className="link" to="/home">
              Home
            </Link>
          </li>
          <li>
            <Link className="link" to="/about">
              About
            </Link>
          </li>
          <li>
            <Link to="/login" className="action_btn link">
              Login
            </Link>
          </li>
        </div>
      </header>
    </div>
  );
}

export default Navbar;
