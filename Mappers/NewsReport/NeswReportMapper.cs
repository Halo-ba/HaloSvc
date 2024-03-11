using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.NewsReport;
using Backend.Models;

namespace Backend.Mappers
{
    public static class NewsReportMapper
    {
         public static NewsReportDto ToNewsReportDto(this NewsReport newsReportModel)
        {
            return new NewsReportDto
            {
                Id = newsReportModel.Id,
                Text = newsReportModel.Text,
                DateOfReport = newsReportModel.DateOfReport,
                Reporter = newsReportModel.Reporter,
                ReporterTelephoneNumber = newsReportModel.ReporterTelephoneNumber,
                Email = newsReportModel.Email
            };
        }

        public static NewsReport ToNewsReportFromCreateDTO(this NewsReportDto newsReportDto)
        {
            return new NewsReport
            {
                Id = newsReportDto.Id,
                Text = newsReportDto.Text,
                DateOfReport = newsReportDto.DateOfReport,
                Reporter = newsReportDto.Reporter,
                ReporterTelephoneNumber = newsReportDto.ReporterTelephoneNumber,
                Email = newsReportDto.Email

            };
        }

        }
}