#include "pch.h"
#include <iostream>
#include <string>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace ClassLibrary2;

int main(array<System::String^>^ args)
{
    String^ name = gcnew String("");
	int count;
	array<Byte>^ color = gcnew array<Byte>(3);
	std::cout << "Введите название команды";
	name = Console::ReadLine();
	name == "clear display" ? count = 0 : count = 4;
	name == "draw pixel" ? count = 2 : count = 4;
	array<Int16>^ par = gcnew array<Int16>(count);
	Int16 a; Byte b;
	for (size_t i = 0; i < count; i++)
	{
		std::cout << "Введите"<<i<<" Параметр команды";
		std::cin >> a;
		par[i] = a;
	}
	std::cout << "Введите цвет(3 байта)";
	for (size_t i = 0; i < 3; i++)
	{
		std::cin >> b;
		color[i] = b;
	}
	
	Builder^ command = gcnew Builder(par,name,color);
	ClientConect::Connect(command->Parse());
    return 0;
}
