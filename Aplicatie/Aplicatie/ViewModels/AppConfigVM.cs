﻿using Aplicatie.Core.Modele;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.ViewModels;

public partial class AppConfigVM : ObservableObject
{
    [ObservableProperty]
    string modDeLucru = string.Empty;

    List<string> ModuriDeLucruPosibile = new();

    [ObservableProperty]
    DateTime lastModified = new DateTime();

    [ObservableProperty]
    string filePath = string.Empty;


    public AppConfigVM(AppConfig appConfig)
    {
        ModDeLucru = appConfig.ModDeLucru;
        ModuriDeLucruPosibile.Clear();
        ModuriDeLucruPosibile.AddRange(appConfig.ModuriDeLucruPosibile);
        LastModified = appConfig.LastModified;
        filePath = appConfig.FilePath;
    }


    public static explicit operator AppConfigVM(AppConfig appConfig)
    {
        return new AppConfigVM(appConfig);
       
    }
}
