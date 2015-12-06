-- phpMyAdmin SQL Dump
-- version 4.1.6
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 25, 2014 at 06:59 PM
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
  `USER_NUMBER` int(11) NOT NULL DEFAULT '0',
  `USER_MAX` int(11) NOT NULL,
  PRIMARY KEY (`CAMP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `camp`
--

INSERT INTO `camp` (`CAMP_ID`, `LOCATION`, `USER_NUMBER`, `USER_MAX`) VALUES
('1', 'Eindhoven', 1, 6),
('2', 'Eindhoven', 1, 6),
('3', 'Eindhoven', 0, 6),
('4', 'Eindhoven', 0, 6);

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
  `DECRIBTION` varchar(400) DEFAULT NULL,
  `EVENTNAME` varchar(20) NOT NULL,
  `LOCATION` varchar(20) NOT NULL,
  `TIME` varchar(40) NOT NULL,
  `USER_MAX` int(11) NOT NULL DEFAULT '50',
  PRIMARY KEY (`EVENT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `event`
--

INSERT INTO `event` (`EVENT_ID`, `DECRIBTION`, `EVENTNAME`, `LOCATION`, `TIME`, `USER_MAX`) VALUES
('1', 'PLAYING', 'playing', 'Eindhoven', 'now', 1),
('2', 'PLAYING', 'playing2', 'Eindhoven', 'now', 50),
('3', 'PLAYING', 'playing3', 'Eindhoven', 'now', 50),
('4', 'PLAYING', 'playing4', 'Eindhoven', 'now', 50),
('5', '', 'playing5', 'Eindhoven', '23/05/2014 19:36:39', 50),
('6', 'hello this is a test', 'playing6', 'Eindhoven', '23/05/2014 19:36:39', 50),
('7', '', 'playing7', 'Eindhoven', '24/05/2014 10:35:18', 50);

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
('19', '1', '1', '608', '14 May 201412:35:05'),
('20', '1', '1', '134', '14 May 201412:50:23'),
('21', '1', '1', '66', '14 May 201412:50:38'),
('22', '1', '1', '229', '14 May 201421:19:37'),
('23', '1', '1', '187', '14 May 201421:21:29'),
('24', '1', '1', '112', '15 May 201415:21:38'),
('25', '1', '1', '176', '16 May 201412:54:47'),
('26', '1', '1', '44', '16 May 201412:54:53'),
('27', '1', '1', '33', '16 May 201421:35:41'),
('28', '1', '1', '44', '16 May 201421:35:44'),
('29', '1', '1', '44', '16 May 201423:30:36'),
('30', '1', '1', '167', '17 May 201411:45:27'),
('31', '1', '1', '145', '17 May 201411:53:33'),
('32', '1', '1', '33', '17 May 201411:59:21'),
('33', '1', '1', '156', '17 May 201413:34:04'),
('34', '1', '1', '110', '17 May 201413:37:46'),
('35', '1', '1', '33', '17 May 201414:17:06'),
('36', '1', '1', '22', '17 May 201414:17:17'),
('37', '1', '1', '22', '17 May 201415:12:50'),
('38', '1', '1', '209', '17 May 201416:16:58'),
('39', '1', '1', '65', '17 May 201416:40:14'),
('40', '1', '1', '130', '17 May 201416:48:57'),
('41', '1', '1', '195', '17 May 201416:55:22'),
('42', '1', '1', '20', '17 May 201417:00:49'),
('43', '1', '1', '209', '17 May 201417:07:52'),
('44', '1', '1', '686', '17 May 201417:11:35'),
('45', '1', '1', '50', '18 May 201409:04:01'),
('46', '1', '1', '175', '18 May 201409:18:01'),
('47', '1', '1', '55', '18 May 201409:18:45'),
('48', '1', '1', '22', '18 May 201409:19:24'),
('49', '1', '1', '110', '18 May 201409:19:34'),
('50', '1', '1', '220', '18 May 201409:23:56'),
('51', '1', '1', '88', '18 May 201410:02:59'),
('52', '1', '1', '290', '20 May 201410:26:11');

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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=107 ;

--
-- Dumping data for table `order_datails`
--

INSERT INTO `order_datails` (`PRODUCT_PRODUCT_ID`, `ORDER_ORDER_ID`, `QUANTITY`, `ORDERDETAILSID`) VALUES
('7', '46', '3', 96),
('3', '47', '1', 97),
('13', '48', '1', 98),
('7', '49', '2', 99),
('15', '50', '2', 100),
('16', '50', '2', 101),
('17', '50', '2', 102),
('1', '51', '3', 103),
('4', '51', '1', 104),
('8', '52', '3', 105),
('7', '52', '2', 106);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE IF NOT EXISTS `product` (
  `PRODUCT_ID` decimal(10,0) NOT NULL,
  `PRODUCT_NAME` varchar(45) NOT NULL,
  `PRICE` decimal(5,2) NOT NULL,
  `RENTAL_PRICE` decimal(5,0) DEFAULT '0',
  `unit` varchar(10) NOT NULL,
  `desc` varchar(100) DEFAULT 'No desc yet',
  PRIMARY KEY (`PRODUCT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`PRODUCT_ID`, `PRODUCT_NAME`, `PRICE`, `RENTAL_PRICE`, `unit`, `desc`) VALUES
('1', 'product1', '22.00', '0', 'PerKilo', 'no'),
('2', 'product2', '20.00', '0', 'PerKilo', 'no'),
('3', 'product3', '11.00', '0', 'PerKilo', 'no'),
('4', 'product4', '22.00', '0', 'PerKilo', 'no'),
('5', 'product5', '55.00', '0', 'PerKilo', 'no'),
('6', 'product6', '55.00', '0', 'PerKilo', 'no'),
('7', 'product7', '10.00', '0', 'PerKilo', 'no'),
('8', 'product8', '90.00', '0', 'PerKilo', 'no'),
('9', 'product9', '12.00', '0', 'PerKilo', 'no'),
('10', 'product10', '20.00', '0', 'PerKilo', 'no'),
('11', 'p11', '22.00', '0', 'PerKilo', 'no desc'),
('12', 'aa', '22.00', '0', 'PerKilo', 'de'),
('13', 'product13', '22.00', '0', 'Perstuck', '22'),
('14', 'product14', '22.00', '0', 'PerKilo', '22'),
('15', 'product15', '33.00', '0', 'Perstuck', 'no desc yet'),
('16', 'product16', '44.00', '0', 'Perstuck', 'not yet'),
('17', 'test', '33.00', '0', 'Perstuck', 'this is test'),
('18', 'test2', '11.00', '0', 'PerKilo', 'thisisatest'),
('19', 'test3', '11.00', '0', 'PerKilo', 'test3'),
('20', 'rental1', '0.00', '11', 'PerDay', 'No desc yet'),
('21', 'rental2', '0.00', '22', 'PerKilo', ''),
('22', 'rental3', '0.00', '55', 'PerKilo', ''),
('23', 'rentaltest', '22.00', '0', 'Perstuck', ''),
('24', 'rental22', '0.00', '100', 'PerKilo', ''),
('25', 'products', '11.00', '0', 'Perstuck', ''),
('26', 'productss', '11.00', '0', 'Perstuck', ''),
('27', 'productrental', '11.00', '0', 'PerDay', ''),
('28', 'productsrental2', '0.00', '11', 'PerDay', '');

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
-- Table structure for table `rent_record`
--

CREATE TABLE IF NOT EXISTS `rent_record` (
  `RENT_RECORD_ID` int(11) NOT NULL AUTO_INCREMENT,
  `shop_SHOP_ID` decimal(10,0) DEFAULT NULL,
  `user_USER_ID` decimal(5,0) DEFAULT NULL,
  `product_PRODUCT_ID` decimal(10,0) DEFAULT NULL,
  `RENT_TIME` varchar(45) DEFAULT NULL,
  `BACK_TIME` varchar(45) DEFAULT NULL,
  `QUANTITY` int(11) DEFAULT NULL,
  `TOTAL_PRICE` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`RENT_RECORD_ID`),
  KEY `fk_RENT_RECORD_shop1_idx` (`shop_SHOP_ID`),
  KEY `fk_RENT_RECORD_user1_idx` (`user_USER_ID`),
  KEY `fk_RENT_RECORD_product1_idx` (`product_PRODUCT_ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=23 ;

--
-- Dumping data for table `rent_record`
--

INSERT INTO `rent_record` (`RENT_RECORD_ID`, `shop_SHOP_ID`, `user_USER_ID`, `product_PRODUCT_ID`, `RENT_TIME`, `BACK_TIME`, `QUANTITY`, `TOTAL_PRICE`) VALUES
(11, '1', '1', '20', '10/05/2014 09:00:21', '23/05/2014 14:52:59', 0, '0.00'),
(12, '1', '1', '22', '15/05/2014 09:18:37', '23/05/2014 14:53:24', 0, '0.00'),
(13, '1', '1', '21', '12/05/2014 09:19:44', '23/05/2014 14:52:53', 0, '0.00'),
(14, '1', '1', '21', '18/05/2014 10:03:17', '23/05/2014 14:52:02', 0, '0.00'),
(15, '1', '1', '20', '18/05/2014 10:03:17', '23/05/2014 14:53:19', 0, '0.00'),
(16, '1', '1', '22', '18/05/2014 10:07:11', '23/05/2014 14:52:27', 0, '0.00'),
(17, '1', '1', '21', '18/05/2014 10:07:11', '23/05/2014 14:52:28', 0, '0.00'),
(18, '1', '1', '20', '18/05/2014 10:07:11', '23/05/2014 14:52:28', 0, '0.00'),
(19, '1', '1', '22', '20/05/2014 10:26:27', '23/05/2014 14:52:27', 0, '0.00'),
(20, '1', '1', '21', '20/05/2014 10:26:27', '23/05/2014 14:51:46', 0, '0.00'),
(21, '1', '1', '22', '23/05/2014 14:55:52', '', 20, '0.00'),
(22, '1', '1', '21', '23/05/2014 14:55:52', '', 10, '0.00');

-- --------------------------------------------------------

--
-- Table structure for table `shop`
--

CREATE TABLE IF NOT EXISTS `shop` (
  `SHOP_ID` decimal(10,0) NOT NULL,
  `SHOP_NAME` varchar(45) NOT NULL,
  `describtion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`SHOP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shop`
--

INSERT INTO `shop` (`SHOP_ID`, `SHOP_NAME`, `describtion`) VALUES
('1', 'jackyni1', NULL),
('2', 'jackyni2', NULL),
('3', 'jackkyni3', NULL),
('4', 'aa', NULL),
('5', 'jackyni4', 'this is a test'),
('6', 'jackyni5', 'this is a test'),
('7', 'jackyni6', 'this is a test'),
('8', 'jackyni7', 'this is a test');

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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=32 ;

--
-- Dumping data for table `shop_product`
--

INSERT INTO `shop_product` (`SHOP_ID`, `PRODUCT_ID`, `SHOP_PRODUCT_ID`, `NUMBERLEFT`) VALUES
('1', '1', 1, 94),
('1', '2', 2, 5),
('1', '3', 3, 20),
('1', '4', 4, 7),
('1', '5', 5, 16),
('1', '6', 6, 14),
('1', '7', 7, 7),
('1', '8', 8, 17),
('2', '7', 9, 7),
('2', '8', 10, 17),
('2', '9', 11, 10),
('2', '10', 12, 10),
('1', '13', 16, 9),
('1', '14', 17, 20),
('1', '15', 18, 18),
('1', '16', 19, 8),
('1', '17', 20, 10),
('1', '18', 21, 20),
('1', '20', 23, 450),
('1', '19', 25, 30),
('1', '21', 26, 115),
('1', '22', 27, 135),
('1', '23', 28, 0),
('1', '24', 29, 180),
('1', '25', 31, 0);

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
  `BALANCE` decimal(10,2) NOT NULL,
  `CAMP_CAMP_ID` decimal(10,0) DEFAULT '0',
  `IN_OUT` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`USER_ID`),
  UNIQUE KEY `USERNAME_UNIQUE` (`USERNAME`),
  UNIQUE KEY `RFID_UNIQUE` (`RFID`),
  KEY `fk_USER_CAMP1_idx` (`CAMP_CAMP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`USER_ID`, `RFID`, `USERNAME`, `PASSWORD`, `USER_LAST_NAME`, `USER_FIRST_NAME`, `ADDRESS`, `PHONE`, `BALANCE`, `CAMP_CAMP_ID`, `IN_OUT`) VALUES
('0', NULL, 'jackyni2', 'jackyni2', 'jacky', 'ni', NULL, NULL, '999999.99', '1', 0),
('1', 'hellohellohellohellohellohellohellohellohello', 'jackyni', 'jackyni', 'jacky', 'ni', '0', '613062093', '99999999.99', '2', 0);

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
-- Dumping data for table `user_event`
--

INSERT INTO `user_event` (`USER_USER_ID`, `EVENT_EVENT_ID`) VALUES
('1', '1'),
('1', '2'),
('1', '3');

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
