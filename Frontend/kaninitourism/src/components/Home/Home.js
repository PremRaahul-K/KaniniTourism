import React from "react";
import Navbar from "../Navbar/Navbar";
import "../Home/Home.css";

function Home() {
  return (
    <div className="Home">
      <div className="HomeCarousel">
        <div className="HomeNavbar">
          <Navbar />
        </div>
        <div className="hero">
          <div className="WelcomeMessage">
            <h1>Welcome!</h1>
            <p className="WelcomeQute">
              Let’s find your dream Destination make with enjoy
            </p>
            <p>
              Make Your Trip is one of the most popular Travel agency for those
              who want to explore the wold and try to make adventure
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Home;
