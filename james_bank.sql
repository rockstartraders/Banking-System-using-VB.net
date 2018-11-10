-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 27, 2018 at 01:57 AM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 7.2.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `james_bank`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `adminid` int(11) NOT NULL,
  `username` varchar(200) NOT NULL,
  `password` int(11) NOT NULL,
  `name` varchar(200) NOT NULL,
  `address` varchar(200) NOT NULL,
  `contactnumber` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`adminid`, `username`, `password`, `name`, `address`, `contactnumber`) VALUES
(489652, 'v-espenjr', 1122, 'James Paul Es', 'cavite', 92760089),
(78963, 'v-paupau', 7879, 'paulski ', '250 Blck ', 9777788);

-- --------------------------------------------------------

--
-- Table structure for table `custinfo`
--

CREATE TABLE `custinfo` (
  `adminid` int(11) NOT NULL,
  `clientid` int(11) NOT NULL,
  `accountno` int(11) NOT NULL,
  `name` varchar(200) NOT NULL,
  `username` varchar(200) NOT NULL,
  `password` int(11) NOT NULL,
  `address` varchar(200) NOT NULL,
  `contactnumber` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `custinfo`
--

INSERT INTO `custinfo` (`adminid`, `clientid`, `accountno`, `name`, `username`, `password`, `address`, `contactnumber`) VALUES
(78963, 234234, 6767867, 'james', 'v-jamesjeng', 1234, 'blok', 6567567),
(78963, 86765443, 11111, 'paul', 'paulski', 9999, 'kawit', 987),
(78963, 1368, 987654354, 'Onjeng', 'v-onj', 8596, 'block 3', 927888);

-- --------------------------------------------------------

--
-- Table structure for table `custtransaction`
--

CREATE TABLE `custtransaction` (
  `clientid` int(11) NOT NULL,
  `accountno` int(11) NOT NULL,
  `recipientaacnt` int(11) NOT NULL,
  `amounttransferred` int(11) NOT NULL,
  `deposit` int(11) NOT NULL,
  `withdrawal` int(11) NOT NULL,
  `availablebalance` int(11) NOT NULL,
  `date` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `custtransaction`
--

INSERT INTO `custtransaction` (`clientid`, `accountno`, `recipientaacnt`, `amounttransferred`, `deposit`, `withdrawal`, `availablebalance`, `date`) VALUES
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 4:12:09 A'),
(0, 7777888, 0, 0, 5000, 0, 7100, ''),
(0, 7777888, 0, 0, 0, 1000, 7100, '10/27/2018 4:24:15 A'),
(0, 7777888, 0, 0, 0, 100, 7100, '10/27/2018 4:28:27 A'),
(0, 7777888, 0, 0, 100, 0, 7100, '10/27/2018 4:30:24 A'),
(0, 7777888, 0, 0, 5000, 0, 7100, '10/27/2018 4:32:04 A'),
(0, 7777888, 78563214, 1000, 0, 0, 7100, '10/27/2018 4:35:47 A'),
(0, 7777888, 0, 0, 0, 10, 7100, '10/27/2018 5:00:51 A'),
(0, 7777888, 0, 0, 0, 50, 7100, '10/27/2018 5:00:51 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 5:00:51 A'),
(0, 7777888, 0, 0, 0, 100, 7100, '10/27/2018 5:00:51 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 5:03:40 A'),
(0, 7777888, 0, 0, 0, 60, 7100, '10/27/2018 5:03:40 A'),
(0, 0, 0, 0, 0, 0, 0, '10/27/2018 5:07:51 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 5:07:51 A'),
(0, 7777888, 0, 0, 0, 50, 7100, '10/27/2018 5:07:51 A'),
(0, 7777888, 0, 0, 0, 50, 7100, '10/27/2018 5:09:42 A'),
(0, 7777888, 0, 0, 0, 100, 7100, '10/27/2018 5:09:42 A'),
(0, 0, 0, 0, 0, 0, 0, '10/27/2018 5:27:36 A'),
(0, 0, 0, 0, 0, 0, 0, '10/27/2018 5:27:36 A'),
(0, 0, 0, 0, 0, 10, 0, '10/27/2018 5:27:36 A'),
(0, 7777888, 0, 0, 0, 900, 7100, '10/27/2018 5:27:36 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 5:46:43 A'),
(0, 7777888, 0, 0, 50, 0, 7100, '10/27/2018 5:46:43 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 5:48:10 A'),
(0, 7777888, 0, 0, 100, 0, 7100, '10/27/2018 5:48:10 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 5:49:49 A'),
(0, 7777888, 0, 0, 321332, 0, 7100, '10/27/2018 5:49:49 A'),
(0, 0, 0, 0, 0, 0, 0, '10/27/2018 5:54:33 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 5:55:08 A'),
(0, 7777888, 0, 0, 100, 0, 7100, '10/27/2018 5:55:08 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 6:17:23 A'),
(0, 7777888, 0, 0, 100, 0, 7100, '10/27/2018 6:17:23 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 6:19:35 A'),
(0, 7777888, 0, 0, 500, 0, 7100, '10/27/2018 6:19:35 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 6:19:55 A'),
(0, 7777888, 0, 0, 0, 20, 7100, '10/27/2018 6:19:55 A'),
(0, 7777888, 0, 0, 0, 150, 7100, '10/27/2018 6:19:55 A'),
(0, 7777888, 2147483647, 0, 0, 0, 7100, '10/27/2018 6:24:32 A'),
(0, 7777888, 0, 0, 5000, 0, 7100, '10/27/2018 6:25:22 A'),
(0, 7777888, 2147483647, 5000, 0, 0, 7100, '10/27/2018 6:25:38 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 6:27:01 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 6:28:36 A'),
(0, 7777888, 87674632, 0, 0, 0, 7100, '10/27/2018 6:28:36 A'),
(0, 7777888, 5435323, 0, 0, 0, 7100, '10/27/2018 6:29:57 A'),
(0, 7777888, 0, 100, 0, 0, 7100, '10/27/2018 6:29:57 A'),
(0, 7777888, 0, 500, 0, 0, 7100, '10/27/2018 6:31:59 A'),
(0, 7777888, 875244210, 0, 0, 0, 7100, '10/27/2018 6:31:59 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 6:32:57 A'),
(0, 7777888, 324234, 0, 0, 0, 7100, '10/27/2018 6:32:57 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 6:34:05 A'),
(0, 7777888, 2147483647, 0, 0, 0, 7100, '10/27/2018 6:34:05 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 6:34:56 A'),
(0, 7777888, 4234234, 0, 0, 0, 7100, '10/27/2018 6:34:56 A'),
(0, 7777888, 0, 3123123, 0, 0, 7100, '10/27/2018 6:34:56 A'),
(0, 7777888, 0, 0, 0, 0, 7100, '10/27/2018 6:36:26 A'),
(0, 7777888, 8765432, 0, 0, 0, 7100, '10/27/2018 6:36:26 A'),
(0, 7777888, 8765432, 600, 0, 0, 7100, '10/27/2018 6:36:26 A'),
(0, 7777888, 54354535, 600, 0, 0, 7100, '10/27/2018 6:36:26 A'),
(0, 7777888, 78963211, 500, 0, 0, 7100, '10/27/2018 6:39:14 A'),
(89637, 89794654, 0, 0, 0, 0, -6000, ''),
(0, 89794654, 0, 0, 0, 0, -6000, '10/27/2018 6:44:41 A'),
(0, 89794654, 0, 0, 5000, 0, -6000, '10/27/2018 6:44:41 A'),
(0, 89794654, 0, 0, 0, 0, -6000, '10/27/2018 6:45:10 A'),
(0, 89794654, 0, 0, 0, 50, -6000, '10/27/2018 6:45:10 A'),
(0, 89794654, 0, 0, 0, 8000, -6000, '10/27/2018 6:45:10 A'),
(0, 89794654, 0, 0, 0, 0, -6000, '10/27/2018 6:45:34 A'),
(0, 89794654, 789878979, 2000, 0, 0, -6000, '10/27/2018 6:45:34 A'),
(0, 89794654, 0, 0, 100, 0, -6000, '10/27/2018 7:10:32 A'),
(0, 89794654, 0, 0, 0, 0, -6000, '10/27/2018 7:10:58 A'),
(0, 89794654, 0, 0, 0, 0, -6000, '10/27/2018 7:11:17 A'),
(0, 89794654, 0, 0, 0, 50, -6000, '10/27/2018 7:11:17 A'),
(0, 89794654, 0, 0, 0, 100, -6000, '10/27/2018 7:11:17 A'),
(0, 89794654, 0, 0, 0, 0, -6000, '10/27/2018 7:14:16 A'),
(0, 89794654, 5654645, 0, 0, 0, -6000, '10/27/2018 7:14:16 A'),
(0, 89794654, 5654645, 1000, 0, 0, -6000, '10/27/2018 7:14:16 A'),
(0, 89794654, 45345453, 4500, 0, 0, -6000, '10/27/2018 7:20:42 A'),
(0, 89794654, 45345453, 100, 0, 0, -6000, '10/27/2018 7:20:42 A'),
(0, 89794654, 534534534, 5, 0, 0, -6000, '10/27/2018 7:23:24 A'),
(0, 89794654, 534534534, 5000, 0, 0, -6000, '10/27/2018 7:23:24 A'),
(0, 89794654, 0, 0, -5000, 0, -6000, '10/27/2018 7:24:54 A'),
(43534, 3242342, 0, 0, 0, 0, -1000, ''),
(0, 3242342, 2147483647, 2000000, 0, 0, -1000, '10/27/2018 7:27:06 A'),
(0, 3242342, 2147483647, 1100000, 0, 0, -1000, '10/27/2018 7:27:06 A'),
(0, 3242342, 2147483647, 1000, 0, 0, -1000, '10/27/2018 7:27:06 A'),
(0, 3242342, 0, 0, 0, 10000, -1000, '10/27/2018 7:30:35 A'),
(0, 7777888, 0, 0, 0, 7200, 0, '10/27/2018 7:32:00 A'),
(234234, 6767867, 0, 0, 0, 0, 1000, ''),
(86765443, 11111, 0, 0, 0, 0, 10000, ''),
(0, 11111, 0, 0, 0, 110000, 0, '10/27/2018 7:38:39 A'),
(0, 11111, 0, 0, 0, 500, 0, '10/27/2018 7:38:39 A'),
(0, 11111, 0, 0, 0, 11000, 0, '10/27/2018 7:38:39 A'),
(0, 11111, 0, 0, 0, 120000, 0, '10/27/2018 7:41:05 A'),
(0, 11111, 0, 0, 0, 500, 0, '10/27/2018 7:41:05 A'),
(1368, 987654354, 0, 0, 0, 0, 5000, ''),
(0, 987654354, 0, 0, 0, 5000, 5000, '10/27/2018 7:48:57 A');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
