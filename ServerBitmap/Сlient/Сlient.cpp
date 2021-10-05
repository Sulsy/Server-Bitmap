#include "pch.h"
#include <iostream>


using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;

int main(array<System::String^>^ args)
{
	int port = 8005;
	try
	{
		while (true)
		{
			IPEndPoint^ ipoint = gcnew IPEndPoint(IPAddress::Parse("127.0.0.1"), port);
			Socket^ lisentsock = gcnew Socket(AddressFamily::InterNetwork, SocketType::Stream, ProtocolType::Tcp);
			ClassLibrary2::Klients^ klient = gcnew ClassLibrary2::Klients(ipoint, lisentsock);
			klient->Conect;
			klient->Massage;
		}
	}
	catch (Exception^ ex)
	{

		Console::WriteLine(ex);
	}
	//ClassLibrary2::
    return 0;
}
