   M S B A M L   `   `   `  ����Z  VClasswork20200603_Contacts_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Classwork20200603_Contacts_MVVM.View$Classwork20200603_Contacts_MVVM.View  5   	   e7clr-namespace:Classwork20200603_Contacts_MVVM.ViewModel)Classwork20200603_Contacts_MVVM.ViewModel  5   	   w@clr-namespace:Classwork20200603_Contacts_MVVM.ViewModel.Commands2Classwork20200603_Contacts_MVVM.ViewModel.Commands  5   	   {Bclr-namespace:Classwork20200603_Contacts_MVVM.ViewModel.Convertors4Classwork20200603_Contacts_MVVM.ViewModel.Convertors  5	   	   9    3Classwork20200603_Contacts_MVVM.View.ContactsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:Classwork20200603_Contacts_MVVM.View     5   	   Fvm7clr-namespace:Classwork20200603_Contacts_MVVM.ViewModel     5   	   Tcommand@clr-namespace:Classwork20200603_Contacts_MVVM.ViewModel.Commands     5   	   SconvBclr-namespace:Classwork20200603_Contacts_MVVM.ViewModel.Convertors     5	   	     � Title$  ContactsWindow��5   	   $	��392��6    $	��929��6-      WindowStyle#���   5   	    � 	Resources 5      2   ,Classwork20200603_Contacts_MVVM.ViewModel.VM  VMG   AClasswork20200603_Contacts_MVVM.ViewModel.Commands.Command_Delete  del	   VME   ?Classwork20200603_Contacts_MVVM.ViewModel.Commands.Command_Edit  edit	   VMK   EClasswork20200603_Contacts_MVVM.ViewModel.Convertors.ConvertorVisible  conv  LightSalmon �� 
TargetType �� Property �� Value  LightSeaGreen��%(  &	       &	      7  &	 +     7  &	 C     &	 V     &	 
      5   
   6     5   
   8   6-     5   
   8   6,     5   
   6    �� 5   
   " ��6$   .�5      ��  � ��$ 80��6'   �� 5       � ��$ 5q�6(   �� 5       � ��$ 5q�6)   �� 5       � ��
 �z���6+   5      �� 5   
   " ��6&   .�5      ��  � ��$	 200��6'   �� 5        � ��$ 40��6(   �� 5!       � ��$ 10q�6(   �� 5"       � ��$ 5q�6)   �� 5#       � ��
 ��� �6+   5$      5'      .��5*      � $��20q�6    � DataContext# [ 6    � RowDefinitions 5+   
   �� 5,      $	��35* �6   �� 5-      $
��286* �6   	 � ColumnDefinitions	 5/   
   �� 50      $
��390* �6   �� 51      $
��255* �6   �� 52      $
��236* �6   .+�55   
   ]� $��3��6   .+�56      o�   	MenuStyle#���  6   $	��Top=�67   .@�57      m� -   5        
 m�Name$

 lang��57        lang#���  6)   .@�58      m� -   5        $
 en��58      
 � Tag$ en��6+    m� IsCheckable .   	 en#��� 	 6\   m� 59      -   5        $
 ua��59      $ ua��6+    m� 	IsChecked .  
 ua#��� 
 6\   5:      m� 5<      -   5        $
 themes��5<       
 themes#���  6+   .@�5=      m� -   5        $
 light��5=      $ 0��6.    .  	 light#���  6^   m� 5>      -   5        $

 dark��5>      $ 1��6.    .    dark#���  6^   5?      5A      5B      �� 5D   
   -   5         ��Name$ 
lbContacts��5D        ListboxStyle#���  6&   $��1��6M   $��10q�6Z   $��2��6�   ��6f   �� *
Contacts+ �� SelectedItem 6�   �� *SelectedContact+��5E      �� 5F      .R�5G      ��  �� Orientation$ 
Horizontal=�6!   .+�5H      �� $��50��6    ��6+   �� *Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5I      $��50��6    ��6+   �� *	SurName+$ TwoWay=�$ PropertyChanged=��� 5J      $��50��6    ��6+   �� *Phone+$ TwoWay=�$ PropertyChanged=��� 5K      #���  6!   $
��Edit��6G   #��[ 6X   ��6z   �� *SelectedContact+$ PropertyChanged=�$ TwoWay=��� 5L      #���  6!   $��Delete��6G   #��[ 6X   ��6w   �� *Phone+5M      5N      5P      �� 5T   
   $��1��6   
�������$��1��6:   $��10q�6J   $��2��6V   y�6g   �� *VisibleCreated+ �� 	Converter# [ .+�5V      �� #���  6   ��6>   �� *Contact.Name+$ TwoWay=�$ PropertyChanged=��� 5W      #���  6   ��6>   �� *Contact.SurName+$ TwoWay=�$ PropertyChanged=��� 5X      #���  6   ��6>   �� *Contact.Phone+$ TwoWay=�$ PropertyChanged=��� 5Y      -   5         ��Name$	 add��5Y      #���  6#     add#���  6J   ��6o   �� *Command_Add+��6�   �� *	Contact+$ PropertyChanged=�$ OneWay=��� 5Z      -	   5        $ cleare��5Z      #���  6%    
 cleare#���  6L   ��6o   �� *Command_Cleare+��6�   �� *	Contact+$ PropertyChanged=�$ TwoWay=�5\      �� 5`   
   $��1��6   
�������$��2��69   $��10q�6I   $��2��6U   y�6f   �� *VisibleEdit+# [ .+�5a      �� #���  6   {�.  ��6>   �� *SelectedContact.Name+6d   �� 5b      #���  6   {�.  ��6>   �� *SelectedContact.SurName+6g   �� 5c      #���  6   ��6>   �� *SelectedContact.Phone+�� 5d      -
   5        $
 save��5d      #���  6$     save#���  6K   ��6m   �� *Command_Save+��6�   �� *TempContact+$ PropertyChanged=�$ TwoWay=��� 5e      -   5        $ close��5e      #���  6$    	 close#���  6K   ��6m   �� *Command_Close+��6�   �� *Phone+5g      5j      5k      