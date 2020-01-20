#ifndef SIMPLE_H
#define SIMPLE_H

#include <QObject>
#include <QMessageBox>

class Simple : public QObject
{
    Q_OBJECT
public:
    explicit Simple(QObject *parent = nullptr);

signals:

public slots:
    void SetValue();
    uint32_t GetValue();

private:
    uint32_t Value_;
};

#endif // SIMPLE_H
