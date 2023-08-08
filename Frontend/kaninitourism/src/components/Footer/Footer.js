import React from "react";
import "../Footer/Footer.css";
import { CiFacebook } from "react-icons/ci";
import { AiOutlineInstagram } from "react-icons/ai";
import { BsTwitter } from "react-icons/bs";
import { AiFillGithub } from "react-icons/ai";

function Footer() {
  return (
    <div className="Footer">
      <div className="row">
        <div className="column">
          <h4>About Us</h4>

          <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed in
            metus euismod, faucibus metus ut, semper nibh. Aenean euismod justo
            eu enim dapibus suscipit.
          </p>
        </div>

        <div className="column">
          <h4>Quick Links</h4>

          <ul>
            <li>
              <a href="#">
                <i className="fa fa-angle-right"></i> Packages
              </a>
            </li>

            <li>
              <a href="#">
                <i className="fa fa-angle-right"></i> Contact us
              </a>
            </li>

            <li>
              <a href="#">
                <i className="fa fa-angle-right"></i> Bug report
              </a>
            </li>
          </ul>
        </div>

        <div className="column">
          <h4>Connect with Us</h4>

          <ul className="social-icons">
            <li>
              <a href="https://www.facebook.com/">
                <CiFacebook className="footericon" />
              </a>
            </li>

            <li>
              <a href="https://www.instagram.com/">
                <AiOutlineInstagram className="footericon" />
              </a>
            </li>

            <li>
              <a href="https://twitter.com/i/flow/login">
                <BsTwitter className="footericon" />
              </a>
            </li>

            <li>
              <a href="https://github.com/prem-kanini">
                <AiFillGithub className="footericon" />
              </a>
            </li>
          </ul>
        </div>
      </div>

      <p className="copyright">© 2023 All Rights Reserved</p>
    </div>
  );
}

export default Footer;
