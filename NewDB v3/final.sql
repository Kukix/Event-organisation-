-- phpMyAdmin SQL Dump
-- version 4.1.6
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 08, 2014 at 04:46 PM
-- Server version: 5.6.16
-- PHP Version: 5.5.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `final`
--

-- --------------------------------------------------------

--
-- Table structure for table `camp`
--

CREATE TABLE IF NOT EXISTS `camp` (
  `CAMP_ID` int(5) NOT NULL AUTO_INCREMENT,
  `LOCATION` varchar(45) NOT NULL,
  `USER_NUMBER` int(11) NOT NULL DEFAULT '0',
  `USER_MAX` int(11) NOT NULL,
  PRIMARY KEY (`CAMP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `customer_payment_methods`
--

CREATE TABLE IF NOT EXISTS `customer_payment_methods` (
  `USER_ID` int(5) NOT NULL,
  `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID` int(5) NOT NULL,
  PRIMARY KEY (`USER_ID`,`REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`),
  KEY `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID_idx` (`REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `event`
--

CREATE TABLE IF NOT EXISTS `event` (
  `EVENT_ID` int(5) NOT NULL AUTO_INCREMENT,
  `DECRIBTION` varchar(400) DEFAULT NULL,
  `EVENTNAME` varchar(20) NOT NULL,
  `LOCATION` varchar(20) NOT NULL,
  `TIME` varchar(40) NOT NULL,
  `USER_MAX` int(11) NOT NULL DEFAULT '50',
  PRIMARY KEY (`EVENT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE IF NOT EXISTS `order` (
  `ORDER_ID` int(5) NOT NULL AUTO_INCREMENT,
  `USER_USER_ID` int(5) NOT NULL,
  `SHOP_SHOP_ID` int(5) NOT NULL,
  `TOTALPRICE` varchar(6) NOT NULL,
  `ORDER_DATE_TIME` varchar(40) NOT NULL,
  PRIMARY KEY (`ORDER_ID`),
  KEY `fk_ORDER_USER1_idx` (`USER_USER_ID`),
  KEY `fk_ORDER_SHOP1_idx` (`SHOP_SHOP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `order_datails`
--

CREATE TABLE IF NOT EXISTS `order_datails` (
  `ORDERDETAILSID` int(11) NOT NULL AUTO_INCREMENT,
  `PRODUCT_PRODUCT_ID` int(5) DEFAULT NULL,
  `ORDER_ORDER_ID` int(5) DEFAULT NULL,
  `QUANTITY` int(5) DEFAULT NULL,
  PRIMARY KEY (`ORDERDETAILSID`),
  KEY `fk_ORDER_DATAILS_PRODUCT1_idx` (`PRODUCT_PRODUCT_ID`),
  KEY `fk_ORDER_DATAILS_ORDER1_idx` (`ORDER_ORDER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE IF NOT EXISTS `product` (
  `PRODUCT_ID` int(5) NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` varchar(45) NOT NULL,
  `PRICE` decimal(5,2) NOT NULL,
  `RENTAL_PRICE` decimal(5,0) DEFAULT '0',
  `unit` varchar(10) NOT NULL,
  `desc` varchar(100) DEFAULT 'No desc yet',
  PRIMARY KEY (`PRODUCT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ref_payment_methods`
--

CREATE TABLE IF NOT EXISTS `ref_payment_methods` (
  `REF_PAYMENT_METHODS_ID` int(5) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`REF_PAYMENT_METHODS_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `rent_record`
--

CREATE TABLE IF NOT EXISTS `rent_record` (
  `RENT_RECORD_ID` int(11) NOT NULL AUTO_INCREMENT,
  `shop_SHOP_ID` int(5) NOT NULL,
  `user_USER_ID` int(5) DEFAULT NULL,
  `product_PRODUCT_ID` int(5) DEFAULT NULL,
  `RENT_TIME` varchar(45) DEFAULT NULL,
  `BACK_TIME` varchar(45) DEFAULT NULL,
  `QUANTITY` int(11) DEFAULT NULL,
  `TOTAL_PRICE` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`RENT_RECORD_ID`),
  KEY `fk_RENT_RECORD_shop1_idx` (`shop_SHOP_ID`),
  KEY `fk_RENT_RECORD_user1_idx` (`user_USER_ID`),
  KEY `fk_RENT_RECORD_product1_idx` (`product_PRODUCT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `shop`
--

CREATE TABLE IF NOT EXISTS `shop` (
  `SHOP_ID` int(5) NOT NULL AUTO_INCREMENT,
  `SHOP_NAME` varchar(45) NOT NULL,
  `describtion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`SHOP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `shop_product`
--

CREATE TABLE IF NOT EXISTS `shop_product` (
  `SHOP_ID` int(5) DEFAULT NULL,
  `PRODUCT_ID` int(5) DEFAULT NULL,
  `SHOP_PRODUCT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `NUMBERLEFT` int(11) DEFAULT NULL,
  PRIMARY KEY (`SHOP_PRODUCT_ID`),
  KEY `PRODUCT_ID_idx` (`PRODUCT_ID`),
  KEY `SHOP_ID` (`SHOP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `USER_ID` int(5) NOT NULL AUTO_INCREMENT,
  `RFID` varchar(45) DEFAULT NULL,
  `USERNAME` varchar(45) NOT NULL,
  `PASSWORD` varchar(128) NOT NULL,
  `SALT` varchar(128) NOT NULL,
  `USER_LAST_NAME` varchar(45) NOT NULL,
  `USER_FIRST_NAME` varchar(45) NOT NULL,
  `ADDRESS` varchar(45) DEFAULT NULL,
  `PHONE` int(10) DEFAULT NULL,
  `BALANCE` decimal(10,2) DEFAULT '0.00',
  `CAMP_CAMP_ID` int(5) DEFAULT NULL,
  `IN_OUT` int(11) DEFAULT '0',
  PRIMARY KEY (`USER_ID`),
  UNIQUE KEY `USERNAME_UNIQUE` (`USERNAME`),
  UNIQUE KEY `RFID_UNIQUE` (`RFID`),
  KEY `fk_USER_CAMP1_idx` (`CAMP_CAMP_ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`USER_ID`, `RFID`, `USERNAME`, `PASSWORD`, `SALT`, `USER_LAST_NAME`, `USER_FIRST_NAME`, `ADDRESS`, `PHONE`, `BALANCE`, `CAMP_CAMP_ID`, `IN_OUT`) VALUES
(7, NULL, 'Kukix', 'e8717a2fb098a8b1d68f8e81342b21c09440df42adbd041c4ed883eec9d7761d', 'e49', 'Petrova', 'Kalina', 'somewhere', 123456789, '0.00', NULL, 0),
(8, NULL, 'Jiaqi', 'af8ecd4d148b9dc3501668c435cf045edeefdae4030c8587bddcf465b86f8d43', '198', 'Ni', 'Jiaqi', 'something', 20409230, '0.00', NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `user_event`
--

CREATE TABLE IF NOT EXISTS `user_event` (
  `USER_USER_ID` int(5) NOT NULL,
  `EVENT_EVENT_ID` int(5) NOT NULL,
  PRIMARY KEY (`USER_USER_ID`,`EVENT_EVENT_ID`),
  KEY `fk_USER_EVENT_EVENT1_idx` (`EVENT_EVENT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `customer_payment_methods`
--
ALTER TABLE `customer_payment_methods`
  ADD CONSTRAINT `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID` FOREIGN KEY (`REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`) REFERENCES `ref_payment_methods` (`REF_PAYMENT_METHODS_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `USER_ID` FOREIGN KEY (`USER_ID`) REFERENCES `user` (`USER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `fk_ORDER_SHOP1` FOREIGN KEY (`SHOP_SHOP_ID`) REFERENCES `shop` (`SHOP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_ORDER_USER1` FOREIGN KEY (`USER_USER_ID`) REFERENCES `user` (`USER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `order_datails`
--
ALTER TABLE `order_datails`
  ADD CONSTRAINT `fk_ORDER_DATAILS_ORDER1` FOREIGN KEY (`ORDER_ORDER_ID`) REFERENCES `order` (`ORDER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_ORDER_DATAILS_PRODUCT1` FOREIGN KEY (`PRODUCT_PRODUCT_ID`) REFERENCES `product` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `rent_record`
--
ALTER TABLE `rent_record`
  ADD CONSTRAINT `fk_RENT_RECORD_product1` FOREIGN KEY (`product_PRODUCT_ID`) REFERENCES `product` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_RENT_RECORD_shop1` FOREIGN KEY (`shop_SHOP_ID`) REFERENCES `shop` (`SHOP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_RENT_RECORD_user1` FOREIGN KEY (`user_USER_ID`) REFERENCES `user` (`USER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `shop_product`
--
ALTER TABLE `shop_product`
  ADD CONSTRAINT `PRODUCT_ID` FOREIGN KEY (`PRODUCT_ID`) REFERENCES `product` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `SHOP_ID` FOREIGN KEY (`SHOP_ID`) REFERENCES `shop` (`SHOP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `fk_USER_CAMP1` FOREIGN KEY (`CAMP_CAMP_ID`) REFERENCES `camp` (`CAMP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `user_event`
--
ALTER TABLE `user_event`
  ADD CONSTRAINT `fk_USER_EVENT_EVENT1` FOREIGN KEY (`EVENT_EVENT_ID`) REFERENCES `event` (`EVENT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_USER_EVENT_USER1` FOREIGN KEY (`USER_USER_ID`) REFERENCES `user` (`USER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
