void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Racket"))
    {
        Vector3 direction = ballModel.CalculateDirection(collision.relativeVelocity, collision.contacts[0].normal);
        CmdSendDirection(direction);
        ballView.UpdateVelocity(ballModel.GetVelocity(direction));
    }
}
