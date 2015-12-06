-- phpMyAdmin SQL Dump
-- version 4.1.6
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 14, 2014 at 12:36 PM
-- Server version: 5.6.16
-- PHP Version: 5.5.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `mydb`
--

-- --------------------------------------------------------

--
-- Table structure for table `camp`
--

CREATE TABLE IF NOT EXISTS `camp` (
  `CAMP_ID` decimal(10,0) NOT NULL,
  `LOCATION` varchar(45) NOT NULL,
  PRIMARY KEY (`CAMP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `customer_payment_methods`
--

CREATE TABLE IF NOT EXISTS `customer_payment_methods` (
  `USER_ID` decimal(10,0) NOT NULL,
  `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID` decimal(10,0) NOT NULL,
  PRIMARY KEY (`USER_ID`,`REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`),
  KEY `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID_idx` (`REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `event`
--

CREATE TABLE IF NOT EXISTS `event` (
  `EVENT_ID` decimal(10,0) NOT NULL,
  `DECRIBTION` varchar(45) NOT NULL,
  PRIMARY KEY (`EVENT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE IF NOT EXISTS `order` (
  `ORDER_ID` decimal(10,0) NOT NULL,
  `USER_USER_ID` decimal(5,0) NOT NULL,
  `SHOP_SHOP_ID` decimal(10,0) NOT NULL,
  `TOTALPRICE` varchar(6) NOT NULL,
  `ORDER_DATE_TIME` varchar(40) NOT NULL,
  PRIMARY KEY (`ORDER_ID`),
  KEY `fk_ORDER_USER1_idx` (`USER_USER_ID`),
  KEY `fk_ORDER_SHOP1_idx` (`SHOP_SHOP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `order`
--

INSERT INTO `order` (`ORDER_ID`, `USER_USER_ID`, `SHOP_SHOP_ID`, `TOTALPRICE`, `ORDER_DATE_TIME`) VALUES
('1', '1', '1', '66.6', ''),
('2', '1', '1', '200', '200'),
('3', '1', '1', '200', '200'),
('4', '1', '1', '200', '12:11:39'),
('5', '1', '1', '200', '14 May 201412:12:08'),
('6', '1', '1', '10', '14 May 201412:12:43'),
('7', '1', '1', '22', '14 May 201412:13:13'),
('8', '1', '1', '44', '14 May 201412:13:32'),
('9', '1', '1', '87', '14 May 201412:13:37'),
('10', '1', '1', '171', '14 May 201412:14:44'),
('11', '1', '1', '40', '14 May 201412:14:50'),
('12', '1', '1', '190', '14 May 201412:15:09'),
('13', '1', '1', '174', '14 May 201412:19:03'),
('14', '1', '1', '22', '14 May 201412:25:35'),
('15', '1', '1', '197', '14 May 201412:25:57'),
('16', '1', '1', '144', '14 May 201412:29:42'),
('17', '1', '1', '87', '14 May 201412:30:47'),
('18', '1', '1', '212', '14 May 201412:31:37'),
('19', '1', '1', '608', '14 May 201412:35:05');

-- --------------------------------------------------------

--
-- Table structure for table `order_datails`
--

CREATE TABLE IF NOT EXISTS `order_datails` (
  `PRODUCT_PRODUCT_ID` decimal(10,0) DEFAULT NULL,
  `ORDER_ORDER_ID` decimal(10,0) DEFAULT NULL,
  `QUANTITY` decimal(10,0) DEFAULT NULL,
  `ORDERDETAILSID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ORDERDETAILSID`),
  KEY `fk_ORDER_DATAILS_PRODUCT1_idx` (`PRODUCT_PRODUCT_ID`),
  KEY `fk_ORDER_DATAILS_ORDER1_idx` (`ORDER_ORDER_ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=23 ;

--
-- Dumping data for table `order_datails`
--

INSERT INTO `order_datails` (`PRODUCT_PRODUCT_ID`, `ORDER_ORDER_ID`, `QUANTITY`, `ORDERDETAILSID`) VALUES
('14', '14', '1', 1),
('6', '15', '1', 2),
('7', '15', '1', 3),
('6', '15', '1', 4),
('5', '15', '1', 5),
('14', '15', '1', 6),
('7', '16', '1', 7),
('8', '16', '1', 8),
('13', '16', '1', 9),
('14', '16', '1', 10),
('5', '17', '1', 11),
('14', '17', '1', 12),
('7', '17', '1', 13),
('8', '18', '1', 14),
('8', '18', '1', 15),
('7', '18', '1', 16),
('13', '18', '1', 17),
('3', '19', '4', 18),
('2', '19', '4', 19),
('3', '19', '4', 20),
('5', '19', '4', 21),
('6', '19', '4', 22);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE IF NOT EXISTS `product` (
  `PRODUCT_ID` decimal(10,0) NOT NULL,
  `PRODUCT_NAME` varchar(45) NOT NULL,
  `PRICE` decimal(5,0) NOT NULL,
  `RENTAL_PRICE` decimal(5,0) DEFAULT '0',
  `unit` varchar(10) NOT NULL,
  `desc` varchar(100) DEFAULT 'No desc yet',
  PRIMARY KEY (`PRODUCT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`PRODUCT_ID`, `PRODUCT_NAME`, `PRICE`, `RENTAL_PRICE`, `unit`, `desc`) VALUES
('1', 'product1', '22', '0', 'PerKilo', 'no'),
('2', 'product2', '20', '0', 'PerKilo', 'no'),
('3', 'product3', '11', '0', 'PerKilo', 'no'),
('4', 'product4', '22', '0', 'PerKilo', 'no'),
('5', 'product5', '55', '0', 'PerKilo', 'no'),
('6', 'product6', '55', '0', 'PerKilo', 'no'),
('7', 'product7', '10', '0', 'PerKilo', 'no'),
('8', 'product8', '90', '0', 'PerKilo', 'no'),
('9', 'product9', '12', '0', 'PerKilo', 'no'),
('10', 'product10', '20', '0', 'PerKilo', 'no'),
('11', 'p11', '22', '0', 'PerKilo', 'no desc'),
('12', 'aa', '22', '0', 'PerKilo', 'de'),
('13', 'product13', '22', '0', 'Perstuck', '22'),
('14', 'product14', '22', '0', 'PerKilo', '22'),
('15', 'product15', '33', '0', 'Perstuck', 'no desc yet'),
('16', 'product16', '44', '0', 'Perstuck', 'not yet'),
('17', 'test', '33', '0', 'Perstuck', 'this is test');

-- --------------------------------------------------------

--
-- Table structure for table `ref_payment_methods`
--

CREATE TABLE IF NOT EXISTS `ref_payment_methods` (
  `REF_PAYMENT_METHODS_ID` decimal(10,0) NOT NULL,
  PRIMARY KEY (`REF_PAYMENT_METHODS_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `shop`
--

CREATE TABLE IF NOT EXISTS `shop` (
  `SHOP_ID` decimal(10,0) NOT NULL,
  `SHOP_NAME` varchar(45) NOT NULL,
  PRIMARY KEY (`SHOP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shop`
--

INSERT INTO `shop` (`SHOP_ID`, `SHOP_NAME`) VALUES
('1', 'jackyni1'),
('2', 'jackyni2');

-- --------------------------------------------------------

--
-- Table structure for table `shop_product`
--

CREATE TABLE IF NOT EXISTS `shop_product` (
  `SHOP_ID` decimal(10,0) DEFAULT NULL,
  `PRODUCT_ID` decimal(10,0) DEFAULT NULL,
  `SHOP_PRODUCT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `NUMBERLEFT` int(11) DEFAULT NULL,
  PRIMARY KEY (`SHOP_PRODUCT_ID`),
  KEY `PRODUCT_ID_idx` (`PRODUCT_ID`),
  KEY `SHOP_ID` (`SHOP_ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=21 ;

--
-- Dumping data for table `shop_product`
--

INSERT INTO `shop_product` (`SHOP_ID`, `PRODUCT_ID`, `SHOP_PRODUCT_ID`, `NUMBERLEFT`) VALUES
('1', '1', 1, 13),
('1', '2', 2, 5),
('1', '3', 3, 2),
('1', '4', 4, 9),
('1', '5', 5, 3),
('1', '6', 6, 3),
('1', '7', 7, 5),
('1', '8', 8, 5),
('2', '7', 9, 5),
('2', '8', 10, 5),
('2', '9', 11, 10),
('2', '10', 12, 10),
('1', '13', 16, 2),
('1', '14', 17, 5),
('1', '15', 18, 5),
('1', '16', 19, 15),
('1', '17', 20, 20);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `USER_ID` decimal(5,0) NOT NULL,
  `RFID` varchar(45) DEFAULT NULL,
  `USERNAME` varchar(45) NOT NULL,
  `PASSWORD` varchar(45) NOT NULL,
  `USER_LAST_NAME` varchar(45) NOT NULL,
  `USER_FIRST_NAME` varchar(45) NOT NULL,
  `ADDRESS` varchar(45) DEFAULT NULL,
  `PHONE` decimal(10,0) DEFAULT NULL,
  `BALANCE` decimal(5,0) NOT NULL,
  `CAMP_ID` decimal(5,0) DEFAULT NULL,
  `CAMP_CAMP_ID` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`USER_ID`),
  UNIQUE KEY `USERNAME_UNIQUE` (`USERNAME`),
  UNIQUE KEY `CAMP_ID_UNIQUE` (`CAMP_ID`),
  UNIQUE KEY `RFID_UNIQUE` (`RFID`),
  KEY `fk_USER_CAMP1_idx` (`CAMP_CAMP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`USER_ID`, `RFID`, `USERNAME`, `PASSWORD`, `USER_LAST_NAME`, `USER_FIRST_NAME`, `ADDRESS`, `PHONE`, `BALANCE`, `CAMP_ID`, `CAMP_CAMP_ID`) VALUES
('1', 'hellohellohellohellohellohellohellohellohello', 'jackyni', 'jackyni', 'jacky', 'ni', NULL, NULL, '200', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `user_event`
--

CREATE TABLE IF NOT EXISTS `user_event` (
  `USER_USER_ID` decimal(5,0) NOT NULL,
  `EVENT_EVENT_ID` decimal(10,0) NOT NULL,
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
