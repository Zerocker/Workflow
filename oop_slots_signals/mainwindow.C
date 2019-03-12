#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "QMessageBox"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    Object = new Simple();

    connect(ui->pushButton, SIGNAL(clicked()),
            Object, SLOT(SetValue()));
    connect(ui->pushButton_2, SIGNAL(clicked()),
            Object, SLOT(GetValue()));
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    QMessageBox::information(this, "Info", QString("Value in A had been changed!\n") +
                             QString("Prev. value: ") + QString::number(Object->GetValue()));
}

void MainWindow::on_pushButton_2_clicked()
{
    QMessageBox::information(this, "Info", QString::number(Object->GetValue()));
}
