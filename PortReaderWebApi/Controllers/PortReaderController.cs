using Newtonsoft.Json;
using PortReaderWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace PortReaderWebApi.Controllers
{
    [RoutePrefix("api/Reader")]
    public class PortReaderController : ApiController
    {
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        [HttpPost]
        [Route("ReadSerialPort")]
        public IHttpActionResult ReadSerialPort([FromBody] PortSubmitModel model)
        {
            logger.Info($"Reading searial port for message: {JsonConvert.SerializeObject(model)}");
            SerialPort port = new SerialPort();
            try
            {
                port.PortName = model.PortName;
                port.Parity = model.Parity;
                port.StopBits = model.StopBits;
                port.DataBits = model.DataBits;
                port.Handshake = model.Handshake;
               
                logger.Info($"Port {port.PortName} is not open, opening port");
                if (!port.IsOpen)
                {
                    port.Open();
                    logger.Info($"Port {port.PortName}, opened port");
                }

                logger.Info($"Port {port.PortName}, writing 'P' to port");
                port.Write($"P");
                Thread.Sleep(300);

                logger.Info($"Port {port.PortName}, reading from port");
                var result = port.ReadExisting();
                logger.Info($"Port {port.PortName}, result from port: {result}");

                port.Close();

                logger.Info($"Port {port.PortName}, closing port");

                return Ok(result);


            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Failed to read serial port for model ({JsonConvert.SerializeObject(model)}, message: {ex.Message})");
                return InternalServerError(ex);
            }
            finally
            {
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }

        [HttpGet]
        [Route("GetAllPorts")]
        public IHttpActionResult GetAll()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                return Ok(ports);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}
