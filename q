[1mdiff --git a/HackerNewsWPFMVVM/Views/StoriesView.xaml b/HackerNewsWPFMVVM/Views/StoriesView.xaml[m
[1mindex 90afc9c..51d66f7 100644[m
[1m--- a/HackerNewsWPFMVVM/Views/StoriesView.xaml[m
[1m+++ b/HackerNewsWPFMVVM/Views/StoriesView.xaml[m
[36m@@ -3,18 +3,10 @@[m
              xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"[m
              xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" [m
              xmlns:d="http://schemas.microsoft.com/expression/blend/2008"[m
[31m-             xmlns:storiesmodel="clr-namespace:HackerNewsWPFMVVM.ModelViews"[m
[31m-             xmlns:converter="clr-namespace:HackerNewsWPFMVVM.ModelViews.Converters"[m
              xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"[m
              mc:Ignorable="d"[m
              d:DesignHeight="450" d:DesignWidth="800">[m
 [m
[31m-    <UserControl.Resources>[m
[31m-        <!--<storiesmodel:StoriesViewModel x:Key="storiesModel"/>[m
[31m-        <storiesmodel:IsLoadingNotifyer x:Key="notifyer"/>[m
[31m-        <converter:BackgroudConverter x:Key="converter"/>-->[m
[31m-    </UserControl.Resources>[m
[31m-[m
     <Grid>[m
         <Grid.RowDefinitions>[m
             <RowDefinition Height="40"/>[m
[36m@@ -30,7 +22,7 @@[m
             <ColumnDefinition Width="20"/>[m
         </Grid.ColumnDefinitions>[m
 [m
[31m- [m
[32m+[m
         <!--Items Menu-->[m
         <DockPanel Grid.Row="0" Grid.Column="0" Background="{StaticResource PrimaryHueMidBrush}" Grid.ColumnSpan="5">[m
 [m
[36m@@ -63,16 +55,24 @@[m
 [m
         <!--Load More Button-->[m
         <DockPanel Grid.Row="2" Grid.Column="2">[m
[31m-            <Button x:Name="loadButton"  Height="30" Content="Load More"[m
[31m-                            Command="{Binding RelativeSource={RelativeSource AncestorType=Window, Mode=FindAncestor}, Path=DataContext.GetStoriesCommand}"[m
[31m-                            CommandParameter="Next"[m
[32m+[m[32m            <Button x:Name="loadButton"  Height="30" Content="{Binding LoadingContent}"[m
[32m+[m[32m                    Command="{Binding RelativeSource={RelativeSource AncestorType=Window, Mode=FindAncestor}, Path=DataContext.GetStoriesCommand}"[m
[32m+[m[32m                    CommandParameter="Next"[m
                     IsEnabled="True"[m
[31m-                    HorizontalAlignment="Stretch"[m
[31m-                    Style="{StaticResource MaterialDesignRaisedButton}"[m
[31m-                    materialDesign:ButtonProgressAssist.Value="-1"[m
[31m-                    materialDesign:ButtonProgressAssist.IsIndicatorVisible="True"[m
[31m-                    materialDesign:ButtonProgressAssist.IsIndeterminate="True">[m
[31m-               [m
[32m+[m[32m                    HorizontalAlignment="Stretch">[m
[32m+[m[32m                <Button.Style>[m
[32m+[m[32m                    <Style TargetType="Button" BasedOn="{StaticResource MaterialDesignRaisedButton}">[m
[32m+[m[32m                        <Setter Property="materialDesign:ButtonProgressAssist.Value" Value="-1" />[m
[32m+[m[32m                        <Setter Property="materialDesign:ButtonProgressAssist.IsIndicatorVisible" Value="True" />[m
[32m+[m[32m                        <Setter Property="materialDesign:ButtonProgressAssist.IsIndeterminate" Value="False" />[m
[32m+[m[32m                        <Style.Triggers>[m
[32m+[m[32m                            <DataTrigger Binding="{Binding IsLoading}" Value="False">[m
[32m+[m[32m                                <Setter Property="materialDesign:ButtonProgressAssist.IsIndeterminate" Value="True" />[m
[32m+[m[32m                            </DataTrigger>[m
[32m+[m[32m                        </Style.Triggers>[m
[32m+[m[32m                    </Style>[m
[32m+[m[32m                </Button.Style>[m
[32m+[m
             </Button>[m
         </DockPanel>[m
 [m
