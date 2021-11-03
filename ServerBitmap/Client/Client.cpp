#include "pch.h"
#include <iostream>
#include <string>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace ClassLibrary2;

int main(array<System::String^>^ args)
{
	setlocale(LC_ALL, "Russian");

	String^ name = gcnew String("");
	array<Byte>^ color = gcnew array<Byte>(3);
	String^ Color;
	Int16 a; String^ b;
	int count;

	while (true)
	{
		try
		{
			Console::WriteLine("¬ведите название команды:  ");
			name = Console::ReadLine();
			name == "clear display" ? count = 0 : count = 4;
			name == "draw pixel" ? count = 2 : count = count;
			array<Int16>^ par = gcnew array<Int16>(count);

			for (int i = 0; i < count; i++)
			{
				std::cout << "¬ведите " << i + 1 << " ѕараметр команды: ";
				par[i] = Convert::ToInt16(Console::ReadLine());
			}

			std::cout << "¬ведите цвет(3 байта по 2 символа на канал)\n";

			for (int i = 0; i < 3; i++)
			{
				color[i] = Convert::ToByte(Console::ReadLine());
			}

			Builder^ command = gcnew Builder(par, name, color);
			Udp::SendMessage(command->Parse());

		}
	    catch (const std::exception&)
	    {
	    	continue;
	    }
	}
		
	return 0;
}
