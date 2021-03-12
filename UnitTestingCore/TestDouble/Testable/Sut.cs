﻿using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTestingCore.TestDouble.Testable
{
    public class Customer
    {
        private readonly IDbGateway _gateway;
        private readonly ILogger _logger;

        public Customer(IDbGateway gateway, ILogger logger)
        {
            _gateway = gateway;
            _logger = logger;
        }

        public decimal CalculateWage(int id)
        {
            //if (!_gateway.Connected)
            //{
            //    return 0;
            //}
            WorkingStatistics ws = null;
            try
            {
                ws = _gateway.GetWorkingStatistics(id);
            }
            catch (Exception ex)
            {
                return 0;
            }
            decimal wage;
            if (ws.PayHourly)
            {
                wage = ws.WorkingHours * ws.HourSalary;
            }
            else
            {
                wage = ws.MonthSalary;
            }
            _logger.Info($"Customer ID={id}, Wage:{wage}");

            return wage;
        }
    }

    public interface ILogger
    {
        void Info(string s);
    }

    public class Logger : ILogger
    {
        public void Info(string s)
        {
            File.WriteAllText(@"C:\tmp:\log.txt", s);
        }
    }

    public interface IDbGateway
    {
        WorkingStatistics GetWorkingStatistics(int id);
        bool Connected { get; }
    }

    public class DbGateway : IDbGateway
    {
        private Dictionary<int, WorkingStatistics> _storage = new Dictionary<int, WorkingStatistics>()
        {
            {1, new WorkingStatistics() {PayHourly = true, WorkingHours = 5, HourSalary = 10}},
            {2, new WorkingStatistics() {PayHourly = false, MonthSalary = 500}},
            {3, new WorkingStatistics() {PayHourly = true, WorkingHours = 8, HourSalary = 100}},
        };
        public WorkingStatistics GetWorkingStatistics(int id)
        {
            return _storage[id];
        }

        public bool Connected { get; }
        //public WorkingStatistics GetWorkingStatistics(int id)
        //{
        //    //a real gateway can experience any possible problems
        //    //like "no connection" throwing an exception
        //    throw new NoConnection();
        //}

        //public bool Connected { get; }
    }

    public class NoConnection : Exception
    {
    }
}